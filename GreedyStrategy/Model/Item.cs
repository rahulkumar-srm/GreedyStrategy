using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Model
{
    internal class Item
    {
        internal double cost;
        internal double weight;
        internal double profit;
        internal double index;

        // item value function 
        public Item(int wt, int val, int index)
        {
            weight = wt;
            profit = val;
            this.index = index;
            cost = val / wt;
        }
    }
}
