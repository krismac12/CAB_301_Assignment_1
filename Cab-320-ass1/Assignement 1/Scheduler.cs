

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }
    public int operations = 0;

	public IJob[] FirstComeFirstServed() 
    {

        IJob[] jobsA = Jobs.ToArray();
        for(int i = 1; i < Jobs.Count; i++)
        {
            IJob job = jobsA[i];
            int j = i - 1;
            while (j >= 0 && jobsA[j].TimeReceived > job.TimeReceived)
            {
                jobsA[j + 1] = jobsA[j];
                operations++;
                j = j - 1;
            }
            jobsA[j + 1] = job;
            operations++;

        }
        return jobsA;

    }

    public IJob[] Priority() {

        IJob[] jobsA = Jobs.ToArray();
        for (int i = 1; i < Jobs.Count; i++)
        {
            IJob job = jobsA[i];
            int j = i - 1;
            while (j >= 0 && jobsA[j].Priority > job.Priority)
            {
                jobsA[j + 1] = jobsA[j];
                operations++;
                j = j - 1;
            }
            jobsA[j + 1] = job;
            operations++;

        }
        return jobsA;


    }

    public IJob[] ShortestJobFirst() {

        return MergeSort(Jobs).ToArray();
    }

    private IJobCollection MergeSort(IJobCollection collection)
    {
        IJob[] jobs = collection.ToArray();
        int n = (int)collection.Count;
        if(n <= 1)
        {
            return collection;
        }

        IJobCollection leftJobs = new JobCollection(collection.Count);
        IJobCollection rightJobs = new JobCollection(collection.Count);


        for (int i = 0; i < n / 2; i++)
        {
            leftJobs.Add(jobs[i]);
        }
        for(int i = n/2;i < n; i++)
        {
            rightJobs.Add(jobs[i]);
        }

        leftJobs = MergeSort(leftJobs);
        rightJobs = MergeSort(rightJobs);

        return Merge(leftJobs, rightJobs, collection);

    }

    private IJobCollection Merge(IJobCollection leftJobs, IJobCollection rightJobs, IJobCollection original)
    {
        JobCollection c = new JobCollection(original.Count);

        IJob[] left = leftJobs.ToArray();
        IJob[] right = rightJobs.ToArray();
        while (leftJobs.Count > 0 && rightJobs.Count > 0)
        {
            if(left[0].ExecutionTime > right[0].ExecutionTime)
            {
                c.Add(right[0]);
                rightJobs.Remove(right[0].Id);
                operations++;
            }
            else
            {
                c.Add(left[0]);
                leftJobs.Remove(left[0].Id);
                operations++;
            }
            left = leftJobs.ToArray();
            right = rightJobs.ToArray();
        }

        while (leftJobs.Count > 0)
        {
            c.Add(left[0]);
            leftJobs.Remove(left[0].Id);
            left = leftJobs.ToArray();
            operations++;
        }

        while (rightJobs.Count > 0)
        {
            c.Add(right[0]);
            rightJobs.Remove(right[0].Id);
            right = rightJobs.ToArray();
            operations++;
        }
        return c;
    }

}