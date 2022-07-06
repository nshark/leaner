using System;
namespace Learner
{
    public class mineMap
    {
        private int x = 0;
        private int y = 0;
        private List<List<MineTile>> map;
        public mineMap()
        {
            map = new();
            List<MineTile> row = new();
            map.Add(row);
            GenerateAdjancent();
        }
        public void GenerateAdjancent()
        {
                addTile(x + 1, y, new MineTile(x + 1, y));
                addTile(x - 1, y, new MineTile(x - 1, y));
                addTile(x, y + 1, new MineTile(x, y+1));
                addTile(x, y - 1, new MineTile(x, y-1));

        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void move(int dx, int dy)
        {
            if (x+dx >= 0 && y+dy >= 0)
            {
                x += dx;
                y += dy;
                GenerateAdjancent();
            }
        }
        public void addTile(int x, int y, MineTile tile)
        {
            if (x >= 0 && y >= 0)
            {
                if (map.Count <= x)
                {
                    while (map.Count <= x)
                    {
                        List<MineTile> row = new();
                        map.Add(row);
                    }    
                }
                if (map[x].Count <= y)
                {
                    while(map[x].Count <= y)
                    {
                        if(x!= 0)
                        {
                            map[0].Add(null);
                        }
                        map[x].Add(null);
                    }
                }
                if (map[x][y] == null)
                {
                    map[x][y] = tile;
                }
            }
        }
        public List<MineTile> getAdjancent(int x, int y)
        {
            List<MineTile> tiles = new();
            if ((x+1) < map.Count && y < map[0].Count && (x + 1) >= 0 && y >= 0)
            {
                if (map[x + 1][y] != null)
                {
                    tiles.Add(map[x + 1][y]);
                }
            }
            if ((x - 1) < map.Count && y < map[0].Count && (x - 1) >= 0 && y >= 0)
            {
                if (map[x - 1][y] != null)
                {
                    tiles.Add(map[x - 1][y]);
                }
            }
            if (x < map.Count && (y+1) < map[0].Count && x >= 0 && (y+1) >= 0)
            {
                if (map[x][y+1] != null)
                {
                    tiles.Add(map[x][y+1]);
                }
            }
            if (x < map.Count && (y - 1) < map[0].Count && x >= 0 && (y - 1) >= 0)
            {
                if (map[x][y - 1] != null)
                {
                    tiles.Add(map[x][y - 1]);
                }
            }
            return tiles;
        }
        public MineTile getMineTile(int x, int y)
        {
            return map[x][y];
        }
    }
}

