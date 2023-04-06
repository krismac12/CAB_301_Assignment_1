using System;
using System.Diagnostics;

namespace Cab_320_ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("\n Unsorted \n");

            JobCollection ran = generateRandom(100);

            IJob[] jobs = ran.ToArray();

            foreach(IJob job in jobs)
            {
                Console.WriteLine(job);
            }

            Scheduler scheduler = new Scheduler(ran);

            IJob[] job_sorted = scheduler.ShortestJobFirst();

            System.Console.WriteLine("\n Sorted \n");

            foreach (IJob job in job_sorted)
            {
                Console.WriteLine(job);
            }





        }

        public static JobCollection generateRandom(int count)
        {
            JobCollection collection = new JobCollection((uint)999);
            Random random = new Random();
            for (int i = 1; i <= count; i++)
            {
                collection.Add(new Job((uint)i, random.Next(1, 100), (uint)random.Next(1,100), (uint)random.Next(1,9)));
            }
            return collection;
        }

        public static long TestTime(int n)
        {
            JobCollection jobs = generateRandom(n);
            
            Scheduler scheduler = new Scheduler(jobs);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            IJob[] sortedJobs = scheduler.FirstComeFirstServed();
            stopwatch.Stop();

            long time = stopwatch.ElapsedTicks;
            return time;
        }

        public static int TestIterations(int n)
        {
            JobCollection jobs = generateRandom(n);

            Scheduler scheduler = new Scheduler(jobs);
            IJob[] sortedJobs = scheduler.ShortestJobFirst();

            return scheduler.operations;

        }
    }
}
