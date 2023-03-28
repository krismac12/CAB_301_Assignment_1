

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

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
                j = j - 1;
            }
            jobsA[j + 1] = job;
        }
        return jobsA;

    }

    public IJob[] Priority() {

        //To be implemented by students
        return Jobs.ToArray();


    }

    public IJob[] ShortestJobFirst() {

        //To be implemented by students
        return Jobs.ToArray();
    }
}