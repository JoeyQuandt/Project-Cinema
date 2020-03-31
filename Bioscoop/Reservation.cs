using System;
using System.Collections.Generic;

public class Reservation
{
    public Guid id;
    //public User user;
    public string user;
    public List<Ticket> ticketlist;
    public MovieTime MovieRoom;

    public Reservation(string user, List<Ticket> ticketlist, MovieTime MovieRoom )
    {
        // Get all new information
        id = Guid.NewGuid();
        //this.user = user;
        this.user = user;
        this.ticketlist = ticketlist;
        this.MovieRoom = MovieRoom;
    }

    // Return details of the reservation
    public string GetReservationDetails()
    {
        return "Name: " + user + "\nTicket amount: ";
    }
}