using GreedyStrategy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Utility
{
    internal class HuffmanPriorityQueue
    {
        HuffmanTreeNode[] items;
        int top = 0;

        public HuffmanPriorityQueue(int size)
        {
            items = new HuffmanTreeNode[size + 1];
        }

        internal void Push(HuffmanTreeNode node)
        {
            int i = ++top;

            while (i > 1 && items[i / 2].Frequency > node.Frequency)
            {
                items[i] = items[i / 2];
                i = i / 2;
            }

            items[i] = node;
        }

        internal HuffmanTreeNode Pop()
        {
            HuffmanTreeNode data = items[1];
            items[1] = items[top];
            items[top--] = null;

            int i = 1;
            int j = i * 2;

            while (j <= top)
            {
                if ((j + 1) <= top && items[j + 1].Frequency < items[j].Frequency)
                {
                    j += 1;
                }

                if (items[j].Frequency < items[i].Frequency)
                {
                    HuffmanTreeNode temp = items[j];
                    items[j] = items[i];
                    items[i] = temp;

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
