using System;
namespace Learner
{
    public class game
    {
        private int Money = 0;
        
        //hashmap to streamline parsing options
        private Dictionary<String, point> parseMap = new Dictionary<string, point>
        {
            { "move left", new point(-1, 0)},
            { "move right", new point(1, 0)},
            { "move up", new point(0, -1)},
            { "move down", new point(0, 1)},
            { "left", new point(-1, 0)},
            { "right", new point(1, 0)},
            { "up", new point(0, -1)},
            { "down", new point(0, 1)},
            {"quit", new point(0, 0)}
        };
        private Dictionary<String, int> valueOfMinerals = new Dictionary<string, int>
        {
            {"stone", 1},
            { "iron", 20},
            {"coal", 5},
            {"diamond", 100},
            { "dirt", 0}
        };
        private bool upgradeMenu = false;
        private mineMap mineMap;
        public game()
        {
            mineMap = new();
        }
        public void run()
        {
            bool Quit = false;
            while (!Quit)
            {
                List<String> options = new();
                createOptions(options);
                options.Add("quit");
                string input = printStateAndGetInput(options);
                //if quit was selected, exit main loop. Quit will alwalys be the last item in the list
                if (input != "")
                {
                    if (int.Parse(input) == options.Count - 1)
                    {
                        Quit = true;
                        break;
                    }
                }
                ParseInput(input, options);
            }
            Console.WriteLine("Quit Succesfully");
        }
        public string printStateAndGetInput(List<String> Options)
        {
            Console.WriteLine("Money: " + Money.ToString() + ", x: " + mineMap.getX().ToString() + ", y: " + mineMap.getY().ToString());
            for (var i = 0; i < Options.Count; i++)
            {
                Console.WriteLine(i.ToString() + ": " + Options[i]);
            }
            string input = Console.ReadLine();
            int dummyInt = 0;
            if (int.TryParse(input, out dummyInt))
            {
                if (int.Parse(input) >= Options.Count)
                {
                    return "";
                }
                else
                {
                    return input;
                }
            }
            else
            {
                return "";
            }
        }
        // modifies the input list, instead of returning. Created to shorten game.run function.
        private void createOptions(List<String> options)
        {   if (upgradeMenu)
            {
                options.Add("Leave Shop");
            }
            else
            {
                options.Add("Shop");
                foreach (MineTile tile in mineMap.getAdjancent(mineMap.getX(), mineMap.getY()))
                {
                    if (tile.mined)
                    {
                        if (tile.x - mineMap.getX() == -1)
                        {
                            options.Add("move left");
                        }
                        if (tile.x - mineMap.getX() == 1)
                        {
                            options.Add("move right");
                        }
                        if (tile.y - mineMap.getY() == -1)
                        {
                            options.Add("move up");
                        }
                        if (tile.y - mineMap.getY() == 1)
                        {
                            options.Add("move down");
                        }
                    }
                    else
                    {
                        if (tile.x - mineMap.getX() == -1)
                        {
                            options.Add("mine " + tile.type + " left");
                        }
                        if (tile.x - mineMap.getX() == 1)
                        {
                            options.Add("mine " + tile.type + " right");
                        }
                        if (tile.y - mineMap.getY() == -1)
                        {
                            options.Add("mine " + tile.type + " up");
                        }
                        if (tile.y - mineMap.getY() == 1)
                        {
                            options.Add("mine " + tile.type + " down");
                        }
                    }
                }
            }
        }
        private void ParseInput(string input, List<string> options)
        {
            if(input == "")
            {
                return;
            }
            var chosenOption = options[int.Parse(input)];
            
            if(chosenOption == "Shop")
            {
                upgradeMenu = true;
            }
            else if(chosenOption == "Leave Shop")
            {
                upgradeMenu = false;
            }
            else if (upgradeMenu)
            {

            }
            else if (chosenOption.Split(' ')[0] == "move")
            {
                mineMap.move(parseMap[chosenOption].x, parseMap[chosenOption].y);
            }
            else
            {
                String[] split = chosenOption.Split(' ');
                String move = split[split.Count() - 1];
                point p = parseMap[move];
                MineTile toMine = mineMap.getMineTile(mineMap.getX() + p.x, mineMap.getY() + p.y);
                toMine.mined = true;
                Money += valueOfMinerals[toMine.type];
                mineMap.move(p.x, p.y);
            }
        }
    }
}


