using System;

public class Room
{
    public Guid id;
    public string name;
    public Seat[] seats;
    public int takenSeats = 0;
    public int seatAmount;

    // Constructor
    public Room(string name, int seatAmount)
	{
        id = Guid.NewGuid();
        this.name = name;
        this.seatAmount = seatAmount;
    }

    // Check if room is full
    public bool IsFull()
    {
        return takenSeats >= seatAmount;
    }

    // Function to fill seats
    public void FillSeats(int amount)
    {
        this.takenSeats += amount;
    }

    // Get amount of available seats
    public int GetAvailableSeats()
    {
        return this.seatAmount - this.takenSeats;
    }
    public string GetRoomName()
    {
        return this.name;
    }
    public int GetTakenSeats()
    {
        return this.takenSeats;
    }

    //Get amount of seats
    public Seat[] GetSeat()
    {
        return this.seats;
    }

}
