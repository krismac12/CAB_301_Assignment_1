﻿using System;

namespace Cab_320_ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            Job job1 = new Job(1, 1, 1, 1);
            Job job2 = new Job(2, 1, 1, 1);
            Job job3 = new Job(3, 1, 1, 1);
            Job job4 = new Job(4, 1, 1, 1);
            Job job5 = new Job(5, 1, 1, 1);
            Job job6 = new Job(6, 1, 1, 1);



            JobCollection collection = new JobCollection(10);
            collection.Add(job1);
            collection.Add(job2);
            collection.Add(job3);
            collection.Add(job4);
            collection.Add(job5);
            collection.Add(job6);

            /*foreach(Job job in collection.jobs)
            {
                System.Console.WriteLine(job.Id);
            }*/

            for (int i = 0; i < collection.count; i++)
            {
                System.Console.WriteLine(collection.jobs[i]);
            }

            collection.Remove(job4.Id);

            System.Console.WriteLine("Removed\n");

            for (int i = 0; i < collection.count; i++)
            {
                System.Console.WriteLine(collection.jobs[i]);
            }

        }
    }
}
