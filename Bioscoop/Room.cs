using System;

public class Room
{
    private Guid roomId;
    private string roomName;
    private int seats;
    private int takenSeats = 0;

    // Constructor
    public Room(string id, string roomName, int seats)
	{
        this.roomId = new Guid(id.Replace("-", ""));
        this.roomName = roomName;
        this.seats = seats;
    }

    // Check if room is full
    public bool IsFull()
    {
        return takenSeats >= seats;
    }

    // Function to fill seats
    public void FillSeats(int amount)
    {
        this.takenSeats += amount;
    }

    // Get amount of available seats
    public int GetAvailableSeats()
    {
        return this.seats - this.takenSeats;
    }
}
