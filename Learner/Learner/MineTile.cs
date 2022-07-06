using System;

namespace Learner
{
    public class MineTile
    {
        public static WeightedRandomList types = new WeightedRandomList(new Dictionary<string, int>
        {
            {"stone", 50},
            {"coal", 10 },
            {"iron", 5},
            {"diamond", 1},
            {"dirt", 50}
        });
        public int x;
        public int y;
        public bool mined = false;
        public String type;
        public MineTile(int x, int y)
        {
            this.x = x;
            this.y = y;
            type = types.getRandom();
        }
    }
}

