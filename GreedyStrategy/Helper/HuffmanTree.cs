using GreedyStrategy.Model;
using GreedyStrategy.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Helper
{
    internal class HuffmanTree
    {
        internal HuffmanTreeNode rootNode;
        private Dictionary<char, int> dictFrequencies;
        HuffmanPriorityQueue huffmanPriorityQueue;

        internal void Build(string input)
        {
            dictFrequencies = input.GroupBy(x => x).ToDictionary(k => k.Key, v => v.Count());
            huffmanPriorityQueue = new HuffmanPriorityQueue(dictFrequencies.Count);

            foreach (var item in dictFrequencies)
            {
                huffmanPriorityQueue.Push(new HuffmanTreeNode { Symbol = item.Key, Frequency = item.Value, Left = null, Right = null });
            }

            while(huffmanPriorityQueue.Count() >= 2)
            {
                HuffmanTreeNode leftNode = huffmanPriorityQueue.Pop();
                HuffmanTreeNode rightNode = huffmanPriorityQueue.Pop();

                HuffmanTreeNode parentNode = new HuffmanTreeNode
                {
                    Frequency = leftNode.Frequency + rightNode.Frequency,
                    Symbol = '*',
                    Left = leftNode,
                    Right = rightNode
                };

                this.rootNode = parentNode;
                huffmanPriorityQueue.Push(parentNode);
            }
        }
    }
}
