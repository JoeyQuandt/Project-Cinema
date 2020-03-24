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

    
}
