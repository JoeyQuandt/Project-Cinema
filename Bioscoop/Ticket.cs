using System;

public class Ticket
{
    public Guid ticketId;
    public Movie movie;
    public DateTime dateTime;
    public Room room;
    public int seatNumber;
    public string type;
    // Constructor
	public Ticket(Movie movie, DateTime dateTime, Room room, int seatNumber, string type)
	{
        ticketId = System.Guid.NewGuid();
        this.movie = movie;
        this.dateTime = dateTime;
        this.room = room;
        this.seatNumber = seatNumber;
        this.type = type;
	}

    public string GetTicketDetails()
    {
        return "Title: "+this.movie + "\n" +"Date: "+ this.dateTime + "\n"  +"Room: "+ this.room.ToString()+ "\n"+"SeatNumber: "+this.seatNumber.ToString();
    }
}
