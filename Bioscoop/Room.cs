using System;
using System.Collections.Generic;

public class Room
{
    public Guid id;
    public string name;
    public List <Seat> seats;
    public int takenSeats = 0;
    public int seatAmount;

    // Constructor
    public Room(string name, int seatAmount, List <Seat> seats)
	{
        id = Guid.NewGuid();
        this.name = name;
        this.seatAmount = seatAmount;
        this.seats = seats; 
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
    public List <Seat> GetSeat()
    {
        return this.seats;
    }

}
