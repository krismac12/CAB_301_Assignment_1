using System;
using System.Diagnostics;


public class JobCollection : IJobCollection {
	public IJob[] jobs;
	public uint count;

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
            }
        }
        return contains;


    }

    public IJob? Find( uint id ) {
        //To be implemented by students
        return jobs[count-1];

    }

    public bool Remove(uint id) {
        //To be implemented by students
        return false;

    }

    public IJob[] ToArray() {
        //To be implemented by students
        return jobs;
    }
}
