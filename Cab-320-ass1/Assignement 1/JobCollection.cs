using System;
using System.Diagnostics;


public class JobCollection : IJobCollection {
	private IJob[] jobs;
	private uint count;

	public JobCollection( uint capacity ) {
		if( !( capacity >= 1 ) ) throw new ArgumentException();
		jobs = new IJob[capacity];
        count = 0;
	}

	public uint Capacity {
		get { return (uint) jobs.Length; }
	}

	public uint Count {
		get { return count; }
	}

	public bool Add( IJob job ) {

        if (!Contains(job.Id))
        {
            jobs[Count] = job;
            count += 1;
            return true;
        }
        else
        {
            return false;

        }

    }

    public bool Contains(uint id) {
        bool contains = false;
        for (int i = 0; i < count; i++)
        {
            if(jobs[i].Id == id)
            {
                contains = true;
                return contains;
            }
        }
        return contains;


    }

    public IJob? Find( uint id ) {
        for(int i = 0; i < count; i++)
        {
            if(jobs[i].Id == id)
            {
                return jobs[i];
            }
        }
        return null;
    }

    public bool Remove(uint id) {
        IJob[] tempJobs = new IJob[Capacity];
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            tempJobs[i] = jobs[i];
            if(jobs[i].Id == id)
            {
                index = i;
            }
        }

        if(index != -1)
        {
            for (int x = (int)(count - 1); x > index; x--)
            {
                tempJobs[x - 1] = jobs[x];
            }
            jobs = tempJobs;
            jobs[(int)(count - 1)] = null;
            count--;
            return true;
        }
        return false;

    }

    public IJob[] ToArray() {
        IJob[] tempJobs = new IJob[count];
        for (int i = 0; i < count; i++)
        {
            tempJobs[i] = jobs[i];

        }
        return tempJobs;
    }
}
