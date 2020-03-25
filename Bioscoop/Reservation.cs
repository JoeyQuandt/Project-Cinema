using System;

public class Reservation
{
    private Guid reservationId;
    private Ticket[] tickets;
    private int ticketAmount;


    public Reservation (Ticket[] tickets, int ticketAmount)
    {
        reservationId = System.Guid.NewGuid();
        this.tickets = tickets;
        this.ticketAmount = ticketAmount;
        
    }

    public string getReservationDetails()
    {
        return "Amount of tickets" +  this.ticketAmount;
    }
}