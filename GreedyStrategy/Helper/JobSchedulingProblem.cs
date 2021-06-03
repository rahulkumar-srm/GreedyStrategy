using GreedyStrategy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Helper
{
    internal class JobSchedulingProblem
    {
        int jobsCount = 0;
        Job[] jobs;
        string[] jobSchedule;

        internal void JobScheduled()
        {
            JobDetails();

            int slots = jobs.Max(x => x.Deadline);
            jobs = jobs.OrderByDescending(x => x.Profit).ToArray();

            jobSchedule = new string[slots];

            for (int i = 0; i < jobsCount; i++)
            {
                for (int j = jobs[i].Deadline - 1; j >= 0; j--)
                {
                    if (String.IsNullOrEmpty(jobSchedule[j]))
                    {
                        jobSchedule[j] = $"J{i + 1}";
                        break;
                    }
                }
            }

            PrintScheduledJob(jobSchedule);
        }

        private void JobDetails()
        {
            Console.Write("\nEnter the count of jobs : ");
            jobsCount = Convert.ToInt32(Console.ReadLine());

            jobs = new Job[jobsCount];

            for (int i = 0; i < jobsCount; i++)
            {
                Job job = new Job();
                Console.Write($"Enter the profit on the job {i + 1} : ");
                job.Profit = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Enter the deadline the job {i + 1} : ");
                job.Deadline = Convert.ToInt32(Console.ReadLine());

                job.Id = $"J{i + 1}";

                jobs[i] = job;

                Console.WriteLine();
            }
        }

        private void PrintScheduledJob(string[] scheduledJobs)
        {
            foreach(var item in scheduledJobs)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();
        }
    }
}
