using System;

namespace Cab_320_ass1
{
    class Program
    {
        static void Main(string[] args)
        {

            JobCollection collection = generateRandom(10);

            /*foreach(Job job in collection.jobs)
            {
                System.Console.WriteLine(job.Id);
            }*/

            for (int i = 0; i < collection.count; i++)
            {
                System.Console.WriteLine(collection.jobs[i]);
            }

            Scheduler scheduler = new Scheduler(collection);

            IJob[] jobs = scheduler.FirstComeFirstServed();

            System.Console.WriteLine("Sorted\n");

            for (int i = 0; i < collection.count; i++)
            {
                System.Console.WriteLine(jobs[i]);
            }

        }

        public static JobCollection generateRandom(int count)
        {
            JobCollection collection = new JobCollection((uint)count);
            Random random = new Random();
            for (int i = 1; i <= count; i++)
            {
                collection.Add(new Job((uint)i, random.Next(1, 100), 1, 1));
            }
            return collection;
        }
    }
}
