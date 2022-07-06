using System;
namespace Learner
{
    public class WeightedRandomList
    {
        private Random r = new();
        public WeightedRandomList(Dictionary<string, int> choiceWeightMap)
        {
            ChoiceWeightMap = choiceWeightMap;
        }

        public Dictionary<string, int> ChoiceWeightMap { get; }
        public String getRandom()
        {
            int total = 0;
            foreach(int i in ChoiceWeightMap.Values)
            {
                total += i;
            }
            int choice = (int)r.NextInt64(total);
            total = 0;
            for (int i = 0; i < ChoiceWeightMap.Count; i++)
            {
                int val = ChoiceWeightMap.ElementAt(i).Value;
                if (choice >= total && choice < val+total)
                {
                    return ChoiceWeightMap.ElementAt(i).Key;
                }
                total += val;

            }
            return ChoiceWeightMap.ElementAt(0).Key;
        }
    }
}

