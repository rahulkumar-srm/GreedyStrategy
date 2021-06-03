using GreedyStrategy.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(
                    Environment.NewLine + "1. Knapsack Problem" + //Time Complexity(nlogn)
                    Environment.NewLine + "2. Job Scheduling Problem" + //Time Complexity(n^2)
                    Environment.NewLine + "3. Optimal Merge Problem" + //Time Complexity(nlogn)
                    Environment.NewLine + "4. Huffman Coding" + //Time Complexity(nlogn)
                    Environment.NewLine + "5. Dijkstra Algorithm" + //Time Complexity(n^2)
                    Environment.NewLine + "0. Exit\n"
                );

                Console.Write("Please select an option : ");

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);
                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    KnapsackProblem knapsackProblem = new KnapsackProblem();
                    Console.WriteLine($"Max profit can be gained : {knapsackProblem.GetMaxProfit()}");
                    Console.WriteLine();
                }
                else if (i == 2)
                {
                    JobSchedulingProblem jobSchedulingProblem = new JobSchedulingProblem();
                    jobSchedulingProblem.JobScheduled();
                }
                else if (i == 3)
                {
                    OptimalMergeProblem optimalMergeProblem = new OptimalMergeProblem();
                    Console.WriteLine("\nMinimum Computations required : " + optimalMergeProblem.MinComputation());
                    Console.WriteLine();
                }
                else if (i == 4)
                {
                    Console.Write("\nPlease enter the string: ");
                    string input = Console.ReadLine();
                    HuffmanCoding huffmanCoding = new HuffmanCoding(); 

                    BitArray encoded = huffmanCoding.Encode(input);

                    Console.Write("\nEncoded: ");
                    foreach (bool bit in encoded)
                    {
                        Console.Write((bit ? 1 : 0) + "");
                    }
                    Console.WriteLine();

                    string decoded = huffmanCoding.Decode(encoded);

                    Console.WriteLine("Decoded: " + decoded);
                    Console.WriteLine();
                }
                else if (i == 5)
                {
                    Console.Write("\nEnter the start vertex : ");
                    int startVertex = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    DijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm();
                    dijkstraAlgorithm.DisplayShortestPath(dijkstraAlgorithm.ShortestPath(startVertex), startVertex);

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
