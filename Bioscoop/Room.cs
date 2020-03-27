using System;

public class Room
{
    public Guid id;
    public string name;
    public int seats;
    public int takenSeats = 0;

    // Constructor
    public Room(string id, string name, int seats)
	{
        this.id = new Guid(id.Replace("-", ""));
        this.name = name;
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
    public string GetRoomName()
    {
        return this.name;
    }
}
