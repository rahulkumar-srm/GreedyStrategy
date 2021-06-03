using GreedyStrategy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Helper
{
    internal class KnapsackProblem
    {
        private int[] weight;
        private int[] profit;
        private int capacity;
        private int itemCount;

        internal double GetMaxProfit()
        {
            ItemDetails();

            double totalProfit = 0;
            Item[] items = new Item[itemCount];

            for(int i = 0; i < itemCount; i++)
            {
                items[i] = new Item(weight[i], profit[i], i);
            }

            items = items.OrderByDescending(x => x.cost).ToArray();

            for(int i = 0; i < itemCount; i++)
            {
                double itemWeight = items[i].weight;

                if (capacity - itemWeight >= 0)
                {
                    totalProfit += items[i].profit;
                    capacity -= (int)itemWeight;
                }
                else
                {
                    double fraction = capacity / itemWeight;
                    totalProfit += (items[i].profit * fraction);
                    capacity = (int)(capacity - (itemWeight * fraction));
                }
            }

            return totalProfit;
        }

        private void ItemDetails()
        {
            Console.Write("\nEnter the count of items to be inserted : ");
            itemCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            weight = new int[itemCount];
            profit = new int[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                Console.Write($"Enter weight of item {i} : ");
                weight[i] = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Enter the profit on the item {i} : ");
                profit[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }

            Console.Write("\nEnter the capacity of the knapsack : ");
            capacity = Convert.ToInt32(Console.ReadLine());
        }
    }
}
