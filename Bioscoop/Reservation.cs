using System;
using System.Collections.Generic;

public class Reservation
{
    public Guid id;
    public User user;
    public List<Ticket> ticketlist;
    public MovieTime movietimes;

    public Reservation(string id, User user, List<Ticket> ticketlist, MovieTime movietimes )
    {
        // Get all new information
        this.id = new Guid(id.Replace("-", ""));
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