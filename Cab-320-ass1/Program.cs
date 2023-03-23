using System;

namespace Cab_320_ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            Job job1 = new Job(2, 1, 1, 1);
            Job job2 = new Job(1, 1, 1, 1);

            JobCollection collection = new JobCollection(10);
            collection.Add(job1);
            collection.Add(job2);
            /*foreach(Job job in collection.jobs)
            {
                System.Console.WriteLine(job.Id);
            }*/

            for(int i = 0; i < collection.count; i++)
            {
                System.Console.WriteLine(collection.jobs[i]);
            }
        }
    }
}
