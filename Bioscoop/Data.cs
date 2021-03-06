﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public static class Data
{
    public static List<Movie> LoadMovies()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/movieData.json"))
        {
            string json = r.ReadToEnd();
            List<Movie> items = JsonConvert.DeserializeObject<List<Movie>>(json);
            return items;
            /*foreach(Movie item in items){
                Console.WriteLine(item.GetMovieDetails() + "\n\n");
            }*/
        }
    }

    public static void AddMovie(string title, string description, int duration)
    {
        Console.WriteLine("Added Movie: " + title );
    }

    public static List<User> LoadUsers()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/userData.json"))
        {
            string json = r.ReadToEnd();
            List<User> items = JsonConvert.DeserializeObject<List<User>>(json);
            return items;
            /*foreach(User item in items){
                Console.WriteLine(item.GetFirstName() +" "+ item.GetLastName() + "\n");
            }*/
        }
    }

    public static List<Actor> LoadActors()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/actorData.json"))
        {
            string json = r.ReadToEnd();
            List<Actor> items = JsonConvert.DeserializeObject<List<Actor>>(json);
            return items;
            /*foreach (Actor item in items)
            {
                Console.WriteLine(item.GetFirstName() + " " + item.GetLastName() + "\n");
            }*/
        }
    }

    public static List<Room> LoadRooms()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/roomData.json"))
        {
            string json = r.ReadToEnd();
            List<Room> items = JsonConvert.DeserializeObject<List<Room>>(json);
            return items;
            /*foreach (Actor item in items)
            {
                Console.WriteLine(item.GetFirstName() + " " + item.GetLastName() + "\n");
            }*/
        }
    }

    public static List<Ticket> LoadTickets()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/ticketData.json"))
        {
            string json = r.ReadToEnd();
            List<Ticket> items = JsonConvert.DeserializeObject<List<Ticket>>(json);
            return items;
            /*foreach(Movie item in items){
                Console.WriteLine(item.GetMovieDetails() + "\n\n");
            }*/
        }
    }

    public static List<MovieTime> LoadMovieTimes()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/movieTimesData.json"))
        {
            string json = r.ReadToEnd();
            List<MovieTime> items = JsonConvert.DeserializeObject<List<MovieTime>>(json);
            return items;
            /*foreach(Movie item in items){
                Console.WriteLine(item.GetMovieDetails() + "\n\n");
            }*/
        }
    }

    public static List<Reservation> LoadReservations()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/reservationData.json"))
        {
            string json = r.ReadToEnd();
            List<Reservation> items = JsonConvert.DeserializeObject<List<Reservation>>(json);
            return items;
            /*foreach(Movie item in items){
                Console.WriteLine(item.GetMovieDetails() + "\n\n");
            }*/
        }
    }

    public static List<Consumption> LoadConsumptions()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/consumptionData.json"))
        {
            string json = r.ReadToEnd();
            List<Consumption> items = JsonConvert.DeserializeObject<List<Consumption>>(json);
            return items;
            /*foreach(Movie item in items){
                Console.WriteLine(item.GetMovieDetails() + "\n\n");
            }*/
        }
    }
    public static List<Seat> LoadSeats()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/seatData.json"))
        {
            string json = r.ReadToEnd();
            List<Seat> items = JsonConvert.DeserializeObject<List<Seat>>(json);
            return items;
            /*foreach(Movie item in items){
                Console.WriteLine(item.GetMovieDetails() + "\n\n");
            }*/
        }
    }
}
