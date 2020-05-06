using System;

public class Seat
{
	public Guid id;
	public int number;
	public bool taken;

	public Seat(int number, bool taken)
	{
		id = Guid.NewGuid();
		this.number = number;
		this.taken = taken;
	}

	public bool getTaken()
	{
		return this.taken;
	}

}
