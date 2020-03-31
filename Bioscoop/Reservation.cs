using System;
using System.Collections.Generic;

public class Reservation
{
    public Guid id;
    public User user;
    public List<Ticket> ticketlist;
    public MovieTime movietimes;

    public Reservation(User user, List<Ticket> ticketlist, MovieTime movietimes )
    {
        // Get all new information
        id = Guid.NewGuid();
        this.user = user;
        this.ticketlist = ticketlist;
        this.movietimes = movietimes;
    }

    // Return details of the reservation
    public string GetReservationDetails()
    {
        return "Name: " + user + "\nTicket amount: ";
    }
}