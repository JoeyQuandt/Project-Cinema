﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class Data
{
    public void LoadMovies()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/movieData.json"))
        {
            string json = r.ReadToEnd();
            List<Movie> items = JsonConvert.DeserializeObject<List<Movie>>(json);
            /*foreach(Movie item in items){
                Console.WriteLine(item.GetMovieDetails() + "\n\n");
            }*/
        }
    }

    public void LoadUsers()
    {
        // Load the movieData.json here and parse to Movie objects
        using (StreamReader r = new StreamReader(@"../../../data/userData.json"))
        {
            string json = r.ReadToEnd();
            List<User> items = JsonConvert.DeserializeObject<List<User>>(json);
            foreach(User item in items){
                Console.WriteLine(item.GetFirstName() +" "+ item.GetLastName() + "\n");
            }
        }
    }
}
