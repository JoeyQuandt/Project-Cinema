using System;

public class Reservation
{
    public Guid reservationID;
    public string user;
    public DateTime dateTime;
    public int ticketAmount;
    public Ticket ticket;

    public Reservation (string user, DateTime dateTime, int ticketAmount, Ticket ticket)
    {
        reservationID = System.Guid.NewGuid();
        this.user = user;
        this.dateTime = dateTime;
        this.ticketAmount = ticketAmount;
        this.ticket = ticket;
    }

    public string GetReservationDetails()
    {
        return "Name: " + user + "\nTicket amount: " + ticketAmount;
    }
}