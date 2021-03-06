﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public static class Administrator
{
    // Function to ask the user to press enter to continue
    private static void PressEnter()
    {
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }

    // Function to give an error to the user.
    private static void ErrorCode()
    {
        ColorChanger.BackgroundColor(ConsoleColor.Black);
        ColorChanger.TextColor(ConsoleColor.Red);
        Console.WriteLine("Error, only use the numbers from the option menu");
        ColorChanger.BackgroundColor(ConsoleColor.Black);
        ColorChanger.TextColor(ConsoleColor.White);
    }

    // Function that lists all movies as possible menu options. 
    private static void ListMoviesAsOptions()
    {
        // Load movies from JSON
        List<Movie> movies = Data.LoadMovies();

        // Initialize loop
        bool loop = true;
        while (loop)
        {

            Console.Clear();
            Console.WriteLine("Choose a movie to see more information or type 'x' to go back.\n");

            // Loop over movies and output the movie title with a number in front of it
            int index = 0;
            foreach (Movie movie in movies)
            {
                Console.WriteLine(index.ToString() + ") " + movie.GetMovieTitle());
                index++;
            }

            // Read user input and try to parse it.
            string option = Console.ReadLine();
            int x = 0;
            if (Int32.TryParse(option, out x))
            {
                // Test if input is in bounds of List
                if (x >= 0 && x < movies.Count)
                {
                    // TODO: polymorphism: delete, show info or edit after this test? (Possibly by adding a function as parameter)
                    // In bounds, show data
                    Console.Clear();
                    Movie movie = movies[x];
                    Console.WriteLine(movie.GetMovieTitle());
                    Console.WriteLine(movie.GetMovieDescription());
                    Console.WriteLine(movie.GetMovieDuration().ToString() + " minutes");
                    Console.WriteLine("Movie for age " + movie.GetAgeRestriction().ToString() + " and older");
                    Console.WriteLine("");
                    // TODO: Show actors and releaseDate

                } else
                {
                    // Out of bounds, show error
                    ColorChanger.BackgroundColor(ConsoleColor.Black);
                    ColorChanger.TextColor(ConsoleColor.Red);
                    Console.WriteLine("Please choose a number between 0 and " + movies.Count.ToString() + ".");
                    ColorChanger.BackgroundColor(ConsoleColor.Black);
                    ColorChanger.TextColor(ConsoleColor.White);
                }
                PressEnter();
            }

            // If user input is not a number
            else
            {
                // Check if it is 'x' and if it isn't show an error.
                if (option.ToLower() != "x")
                {
                    ErrorCode();
                    PressEnter();
                }
                else
                {
                    // Go back to the admin menu if the user input was 'x'
                    loop = false;
                }
            }
        }
        
    }

    // Function that lists all movies as possible menu options and asks which to change with a wizard to change it
    private static void ChangeMovie()
    {
        // Load movies from JSON
        List<Movie> movies = Data.LoadMovies();

        // Initialize loop
        bool loop = true;
        while (loop)
        {

            Console.Clear();
            Console.WriteLine("Choose a movie to change it or type 'x' to go back.\n");

            // Loop over movies and output the movie title with a number in front of it
            int index = 0;
            foreach (Movie movie in movies)
            {
                Console.WriteLine(index.ToString() + ") " + movie.GetMovieTitle());
                index++;
            }

            // Read user input and try to parse it.
            string option = Console.ReadLine();
            int x = 0;
            if (Int32.TryParse(option, out x))
            {
                // Test if input is in bounds of List
                if (x >= 0 && x < movies.Count)
                {
                    // In bounds, show data
                    Console.Clear();
                    Movie movie = movies[x];
                    // Clear console
                    Console.Clear();
                    ColorChanger.BackgroundColor(ConsoleColor.White);
                    ColorChanger.TextColor(ConsoleColor.Black);
                    Console.WriteLine("Welcome to the 'Change a movie' wizard!");
                    ColorChanger.BackgroundColor(ConsoleColor.Black);
                    ColorChanger.TextColor(ConsoleColor.White);

                    // Ask user for the movie information
                    Console.WriteLine("Please insert the new name of the movie:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Please insert the new description of the movie:");
                    string description = Console.ReadLine();
                    Console.WriteLine("And finally, insert the new duration in minutes of the movie:");

                    // Parse number 
                    // TODO: error if not a number and let the user try again
                    int temp = 0;
                    Int32.TryParse(Console.ReadLine(), out temp);
                    int duration = temp;

                    // Loop for a correct answer
                    bool loop2 = true;
                    while (loop2)
                    {
                        // Repeat the details and ask if its okay
                        Console.Clear();
                        ColorChanger.BackgroundColor(ConsoleColor.White);
                        ColorChanger.TextColor(ConsoleColor.Black);
                        Console.WriteLine("Movie details:");
                        ColorChanger.BackgroundColor(ConsoleColor.Black);
                        ColorChanger.TextColor(ConsoleColor.White);
                        Console.WriteLine(title);
                        Console.WriteLine(description);
                        Console.WriteLine(duration.ToString());
                        Console.WriteLine("\nChange this movie? (y/n)");

                        string inp = Console.ReadLine().ToLower();
                        // If admin wants to change movie
                        if (inp == "y")
                        {
                            Console.Clear();
                            loop2 = false;
                            ColorChanger.BackgroundColor(ConsoleColor.Black);
                            ColorChanger.TextColor(ConsoleColor.Green);
                            Console.WriteLine("Changed the movie to: " + title + "!");
                            ColorChanger.BackgroundColor(ConsoleColor.Black);
                            ColorChanger.TextColor(ConsoleColor.White);

                            // Update JSON by adding the changed movie
                            List<Movie> list = Data.LoadMovies();
                            list.Add(new Movie(title, description, duration, null, DateTime.Now));
                            var SerializedList = JsonConvert.SerializeObject(list, Formatting.Indented);
                            File.WriteAllText(@"../../../data/movieData.json", SerializedList);

                            // Update json by removing the old movie at index 'x'
                            List<Movie> list2 = Data.LoadMovies();
                            list.RemoveAt(x);
                            var SerializedList2 = JsonConvert.SerializeObject(list, Formatting.Indented);
                            File.WriteAllText(@"../../../data/movieData.json", SerializedList2);

                            movies = Data.LoadMovies();

                        }
                        else if (inp == "n")
                        {
                            Console.Clear();
                            loop2 = false;
                            Console.WriteLine("Didn't change the movie " + title + "!");
                            Console.WriteLine("Returning to the admin menu");
                            PressEnter();
                        }
                        else
                        {
                            Console.Clear();
                            ColorChanger.BackgroundColor(ConsoleColor.Black);
                            ColorChanger.TextColor(ConsoleColor.Red);
                            Console.WriteLine("Please choose 'y' or 'n'");
                            ColorChanger.BackgroundColor(ConsoleColor.Black);
                            ColorChanger.TextColor(ConsoleColor.White);
                            PressEnter();
                        }
                    }
                    Console.WriteLine("");
                }
                else
                {
                    // Out of bounds, show error
                    ColorChanger.BackgroundColor(ConsoleColor.Black);
                    ColorChanger.TextColor(ConsoleColor.Red);
                    Console.WriteLine("Please choose a number between 0 and " + movies.Count.ToString() + ".");
                    ColorChanger.BackgroundColor(ConsoleColor.Black);
                    ColorChanger.TextColor(ConsoleColor.White);
                }
                PressEnter();
            }

            // If user input is not a number
            else
            {
                // Check if it is 'x' and if it isn't show an error.
                if (option.ToLower() != "x")
                {
                    ErrorCode();
                    PressEnter();
                }
                else
                {
                    // Go back to the admin menu if the user input was 'x'
                    loop = false;
                }
            }
        }

    }


    // Function that lists all movies as possible menu options and asks which to remove
    private static void RemoveMovie()
    {
        // Load movies from JSON
        List<Movie> movies = Data.LoadMovies();

        // Initialize loop
        bool loop = true;
        while (loop)
        {

            Console.Clear();
            Console.WriteLine("Choose a movie to delete it or type 'x' to go back.\n");

            // Loop over movies and output the movie title with a number in front of it
            int index = 0;
            foreach (Movie movie in movies)
            {
                Console.WriteLine(index.ToString() + ") " + movie.GetMovieTitle());
                index++;
            }

            // Read user input and try to parse it.
            string option = Console.ReadLine();
            int x = 0;
            if (Int32.TryParse(option, out x))
            {
                // Test if input is in bounds of List
                if (x >= 0 && x < movies.Count)
                {
                    // In bounds, show data
                    Console.Clear();
                    Movie movie = movies[x];

                    // Update json by removing the movie at index 'x'
                    List<Movie> list = Data.LoadMovies();
                    list.RemoveAt(x);
                    var SerializedList = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(@"../../../data/movieData.json", SerializedList);

                    Console.WriteLine("Removed " + movie.GetMovieTitle() + ".");
                    Console.WriteLine("");
                    // reload movie list
                    movies = Data.LoadMovies();
                }
                else
                {
                    // Out of bounds, show error
                    ColorChanger.BackgroundColor(ConsoleColor.Black);
                    ColorChanger.TextColor(ConsoleColor.Red);
                    Console.WriteLine("Please choose a number between 0 and " + movies.Count.ToString() + ".");
                    ColorChanger.BackgroundColor(ConsoleColor.Black);
                    ColorChanger.TextColor(ConsoleColor.White);
                }
                PressEnter();
            }

            // If user input is not a number
            else
            {
                // Check if it is 'x' and if it isn't show an error.
                if (option.ToLower() != "x")
                {
                    ErrorCode();
                    PressEnter();
                }
                else
                {
                    // Go back to the admin menu if the user input was 'x'
                    loop = false;
                }
            }
        }

    }
        

    private static void AddMovie()
    {
        // Clear console
        Console.Clear();
        ColorChanger.BackgroundColor(ConsoleColor.White);
        ColorChanger.TextColor(ConsoleColor.Black);
        Console.WriteLine("Welcome to the 'Add a movie' wizard!");
        ColorChanger.BackgroundColor(ConsoleColor.Black);
        ColorChanger.TextColor(ConsoleColor.White);

        // Ask user for the movie information
        Console.WriteLine("Please insert the name of the movie:");
        string title = Console.ReadLine();
        Console.WriteLine("Please insert the description of the movie:");
        string description = Console.ReadLine();
        Console.WriteLine("And finally, insert the duration in minutes of the movie:");

        // Parse number 
        // TODO: error if not a number and let the user try again
        int temp = 0;
        Int32.TryParse(Console.ReadLine(), out temp);
        int duration = temp;

        // Loop for a correct answer
        bool loop = true;
        while (loop)
        {
            // Repeat the details and ask if its okay
            Console.Clear();
            Console.WriteLine("Movie details:");
            Console.WriteLine(title);
            Console.WriteLine(description);
            Console.WriteLine(duration.ToString());
            Console.WriteLine("\nAdd this movie? (y/n)");

            string inp = Console.ReadLine().ToLower();
            if (inp == "y")
            {
                Console.Clear();
                loop = false;

                // Update JSON
                List<Movie> list = Data.LoadMovies();
                list.Add(new Movie(title, description, duration, null, DateTime.Now));
                var SerializedList = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(@"../../../data/movieData.json", SerializedList);

                ColorChanger.BackgroundColor(ConsoleColor.Black);
                ColorChanger.TextColor(ConsoleColor.Green);
                Console.WriteLine("Added the movie " + title + "!");
                ColorChanger.BackgroundColor(ConsoleColor.Black);
                ColorChanger.TextColor(ConsoleColor.White);

                PressEnter();

            } else if(inp == "n")
            {
                Console.Clear();
                loop = false;
                Console.WriteLine("Didn't add the movie " + title + "!");
                Console.WriteLine("Returning to the admin menu");
                PressEnter();
            } 
            else
            {
                Console.Clear();

                ColorChanger.BackgroundColor(ConsoleColor.Black);
                ColorChanger.TextColor(ConsoleColor.Red);
                Console.WriteLine("Please choose 'y' or 'n'");
                ColorChanger.BackgroundColor(ConsoleColor.Black);
                ColorChanger.TextColor(ConsoleColor.White);

                PressEnter();
            }
        }

    }

    public static void AdminMenu()
    {

        bool loop = true;
        while (loop)
        {
            Console.Clear();

            // Present the menu options
            ColorChanger.BackgroundColor(ConsoleColor.White);
            ColorChanger.TextColor(ConsoleColor.Black);
            Console.WriteLine("Welcome to the admin dashboard");
            ColorChanger.BackgroundColor(ConsoleColor.Black);
            ColorChanger.TextColor(ConsoleColor.White);

            Console.WriteLine("");
            Console.WriteLine("1) Show movie times and availability");
            Console.WriteLine("2) Show list of current available movies");
            Console.WriteLine("3) Show ticket information");
            Console.WriteLine("4) Show all consumptions");
            Console.WriteLine("5) Search for a movie");
            Console.WriteLine("6) View all movies");
            Console.WriteLine("7) Add a movie");
            Console.WriteLine("8) Edit a movie");
            Console.WriteLine("9) Remove a movie");
            Console.WriteLine("10) Exit the admin part and go back to the main menu");
            // Prompt the user to choose
            switch (Console.ReadLine())
            {
                case "1":
                    Menu.ShowMovieDetails();
                    continue;
                case "2":
                    Menu.ShowAvailableMovies();
                    continue;
                case "3":
                    Menu.ShowTicketDetails();
                    continue;
                case "4":
                    Menu.ShowConsumptionDetails();
                    continue;
                case "5":
                    Menu.SearchMovies();
                    continue;
                case "6":
                    ListMoviesAsOptions();
                    continue;
                case "7":
                    AddMovie();
                    continue;
                case "8":
                    ChangeMovie();
                    continue;
                case "9":
                    RemoveMovie();
                    continue;
                case "10":
                    loop = false;
                    continue;
                default:
                    ErrorCode();
                    PressEnter();
                    continue;
            }
        }
    }
}
