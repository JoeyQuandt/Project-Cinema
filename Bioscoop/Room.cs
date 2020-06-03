using System;
using System.Collections.Generic;

public class Room
{
    public Guid id;
    public string name;
    public int seats;
    public int takenSeats = 0;

    // Constructor
    public Room(string name, int seats)
	{
        id = Guid.NewGuid();
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
    public int GetTakenSeats()
    {
        return this.takenSeats;
    }
    public List<Seat> GetSeat()
    {
        return this.seats;
    }
}
