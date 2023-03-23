﻿using System;


public class Job : IJob {
	public Job( uint jobId, int timeReceived, uint executionTime, uint priority ) {
		Id = jobId;
		TimeReceived = timeReceived;
		ExecutionTime = executionTime;
		Priority = priority;
	}

	private uint id;
	private int timeReceived;
	private uint executionTime;
	private uint priority;

	public uint Id {
        get
        {
			return id;
		}
		private set {
			if (!IsValidId( value ))
				throw new ArgumentOutOfRangeException( nameof( Id ) );
			id = value;
		}
	}

	public int TimeReceived {
		get {
			return timeReceived;
		}
		private set {
			timeReceived = value;
		}
	}

	public uint ExecutionTime {
		get {
			return executionTime;
		}
		private set {
			if (!IsValidExecutionTime( value ))
				throw new ArgumentOutOfRangeException( nameof( ExecutionTime ) );
			executionTime = value;
		}
	}

	public uint Priority {
		get {
			return priority;
		}
		private set {
			if (!IsValidPriority( value ))
				throw new ArgumentException( nameof( Priority ) );
			priority = value;
		}
	}

	public static bool IsValidId( uint id ) {

		if(id >= 1 && id <= 999)
        {
			return true;

		}
        else
        {
			return false;
        }


	}

	public static bool IsValidExecutionTime( uint executiontime ) {

		if( executiontime > 0)
        {
			return true;

		}
        else
        {
			return false;
        }


	}

	public static bool IsValidPriority( uint priority ) {


		if (priority >= 1 && priority <= 9)
		{
			return true;

		}
		else
		{
			return false;
		}


	}

	public static bool IsTimeReceived(uint time) {

		//To be implemented by students
		return true;

    }

    public override string ToString() {
		return $"Job(jobId: {id}, timeReceived: {timeReceived}, executionTime: {executionTime}, priority: {priority})";
	}
}
