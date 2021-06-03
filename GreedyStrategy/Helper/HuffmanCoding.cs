using GreedyStrategy.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Helper
{
    internal class HuffmanCoding
    {
        HuffmanTree huffmanTree = new HuffmanTree();

        public BitArray Encode(string source)
        {
            huffmanTree.Build(source);

            List<bool> encodedSource = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = huffmanTree.rootNode.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            BitArray bits = new BitArray(encodedSource.ToArray());

            return bits;
        }

        public string Decode(BitArray bits)
        {
            HuffmanTreeNode current = huffmanTree.rootNode;
            string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Symbol;
                    current = huffmanTree.rootNode;
                }
            }

            return decoded;
        }

        public bool IsLeaf(HuffmanTreeNode node)
        {
            return (node.Left == null && node.Right == null);
        }
    }
}
