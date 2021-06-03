using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Utility
{
    internal class MinPriorityQueue
    {
        int[] items;
        int top = 0;

        public MinPriorityQueue(int size)
        {
            items = new int[size + 1];
        }

        internal void Push(int data)
        {
            int i = ++top;

            while(i > 1 && items[i / 2] > data)
            {
                items[i] = items[i / 2];
                i = i / 2;
            }

            items[i] = data;
        }

        internal int Pop()
        {
            int data = items[1];
            items[1] = items[top];
            items[top--] = 0;

            int i = 1;
            int j = i * 2;

            while(j <= top)
            {
                if((j + 1) <= top && items[j + 1] < items[j])
                {
                    j += 1;
                }

                if (items[j] < items[i])
                {
                    int tempData = items[j];
                    items[j] = items[i];
                    items[i] = tempData;

                    i = j;
                    j = i * 2;
                }
                else
                    break;
            }

            return data;
        }

        internal int Count()
        {
            return top;
        }
    }
}
