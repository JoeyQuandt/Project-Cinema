using System;

public class Ticket
{
    public Guid id;
    public int seatNumber;
    public string type;
    // Constructor
	public Ticket(int seatNumber, string type)
	{
        id = Guid.NewGuid();
        this.seatNumber = seatNumber;
        this.type = type;
	}
}
