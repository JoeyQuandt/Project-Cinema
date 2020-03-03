﻿using System;

public class Ticket
{
    private Guid ticketId;
    private Movie movie;
    private DateTime dateTime;
    private double price;
    private Room room;
    private int seatNumber;

    // Constructor
	public Ticket(Movie movie, DateTime dateTime, double price, Room room, int seatNumber)
	{
        ticketId = System.Guid.NewGuid();
        this.movie = movie;
        this.dateTime = dateTime;
        this.price = price;
        this.room = room;
        this.seatNumber = seatNumber;
	}
}
