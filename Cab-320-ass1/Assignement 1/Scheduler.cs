

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

        //To be implemented by students
        return Jobs.ToArray();


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

        IJobCollection left_jobs = new JobCollection(collection.Count);
        IJobCollection right_jobs = new JobCollection(collection.Count);


        for (int i = 0; i < n / 2; i++)
        {
            left_jobs.Add(jobs[i]);
        }
        for(int i = n/2;i < n; i++)
        {
            right_jobs.Add(jobs[i]);
        }

        left_jobs = MergeSort(left_jobs);
        right_jobs = MergeSort(right_jobs);

        return Merge(left_jobs, right_jobs, collection);

    }

    private IJobCollection Merge(IJobCollection left_jobs, IJobCollection right_jobs, IJobCollection original)
    {
        JobCollection c = new JobCollection(original.Count);

        IJob[] left = left_jobs.ToArray();
        IJob[] right = right_jobs.ToArray();
        while (left_jobs.Count > 0 && right_jobs.Count > 0)
        {
            if(left[0].ExecutionTime > right[0].ExecutionTime)
            {
                c.Add(right[0]);
                right_jobs.Remove(right[0].Id);
            }
            else
            {
                c.Add(left[0]);
                left_jobs.Remove(left[0].Id);
            }
            left = left_jobs.ToArray();
            right = right_jobs.ToArray();
        }

        while (left_jobs.Count > 0)
        {
            c.Add(left[0]);
            left_jobs.Remove(left[0].Id);
            left = left_jobs.ToArray();
        }

        while (right_jobs.Count > 0)
        {
            c.Add(right[0]);
            right_jobs.Remove(right[0].Id);
            right = right_jobs.ToArray();
        }
        return c;
    }

}