using System;
using System.Collections.Generic;

public class Reservation
{
    public Guid id;
    public string user;
    public List<Ticket> ticketlist;
    public MovieTime movieRoom;

    public Reservation(string user, List<Ticket> ticketlist, MovieTime MovieRoom )
    {
        // Get all new information
        id = Guid.NewGuid();
        this.user = user;
        this.ticketlist = ticketlist;
        this.movieRoom = MovieRoom;
    }

    // Return details of the reservation
    public string GetReservationDetails()
    {
        int ticketAmount = 0;
        foreach (Ticket ticket in ticketlist) {
            ticketAmount++;
        }
       
        return "Name: " + user + "\nMovie: " + movieRoom.GetMovieTimeDetails() + "\nTicket amount: " + ticketAmount;
    }

    public string GetReservationUser()
    {
        return user;
    }
}
