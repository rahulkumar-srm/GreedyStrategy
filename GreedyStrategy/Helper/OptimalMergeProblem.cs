using GreedyStrategy.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Helper
{
    internal class OptimalMergeProblem
    {
        MinPriorityQueue minPriorityQueue;

        private void ListDetails()
        {
            Console.Write("\nEnter the count of lists : ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            minPriorityQueue = new MinPriorityQueue(count);

            for(int i = 0; i < count; i++)
            {
                Console.Write($"Enter the size of list { i + 1} : ");
                minPriorityQueue.Push(Convert.ToInt32(Console.ReadLine()));
            }
        }

        internal int MinComputation()
        {
            ListDetails();

            int totalComputation = 0;

            while(minPriorityQueue.Count() > 1)
            {
                int data = minPriorityQueue.Pop() + minPriorityQueue.Pop();
                totalComputation += data;
                minPriorityQueue.Push(data);
            }

            return totalComputation;
        }
    }
}
