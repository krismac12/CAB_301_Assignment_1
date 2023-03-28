using System;
using System.Diagnostics;

namespace Cab_320_ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            long time1 = TestTime(1);
            long time2 = TestTime(2);
            long time3 = TestTime(10);
            System.Console.WriteLine(time1);
            System.Console.WriteLine(time2);
            System.Console.WriteLine(time3);

        }

        public static JobCollection generateRandom(int count)
        {
            JobCollection collection = new JobCollection((uint)count);
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
    }
}
