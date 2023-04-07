using System;
using System.Diagnostics;

namespace Cab_320_ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int time1 = TestIterations(100);
            int time2 = TestIterations(200);
            int time3 = TestIterations(300);
            int time4 = TestIterations(400);
            int time5 = TestIterations(500);
            int time6 = TestIterations(600);
            int time7 = TestIterations(700);
            int time8 = TestIterations(800);
            int time9 = TestIterations(900);
            int time10 = TestIterations(999);
            System.Console.WriteLine(time1);
            System.Console.WriteLine(time2);
            System.Console.WriteLine(time3);
            System.Console.WriteLine(time4);
            System.Console.WriteLine(time5);
            System.Console.WriteLine(time6);
            System.Console.WriteLine(time7);
            System.Console.WriteLine(time8);
            System.Console.WriteLine(time9);
            System.Console.WriteLine(time10);
            */

            /*
            System.Console.WriteLine("\n Unsorted \n");

            JobCollection ran = generateRandom(10);

            IJob[] jobs = ran.ToArray();

            foreach (IJob job in jobs)
            {
                Console.WriteLine(job);
            }

            Scheduler scheduler = new Scheduler(ran);

            IJob[] job_sorted = scheduler.ShortestJobFirst();

            System.Console.WriteLine("\n Sorted \n");

            foreach (IJob job in job_sorted)
            {
                Console.WriteLine(job);
            }*/

            bool bool1 = Job.IsValidExecutionTime(1);
            bool bool2 = Job.IsValidExecutionTime(999);
            bool bool3 = Job.IsValidExecutionTime(0);
            bool bool4 = Job.IsValidExecutionTime(9999);



            System.Console.WriteLine("\n bool1 :"+bool1+" \n");
            System.Console.WriteLine("\n bool2 :" + bool2 + " \n");
            System.Console.WriteLine("\n bool3 :" + bool3 + " \n");
            System.Console.WriteLine("\n bool4 :" + bool4 + " \n");


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
            IJob[] sortedJobs = scheduler.Priority();

            return scheduler.operations;

        }
    }
}
