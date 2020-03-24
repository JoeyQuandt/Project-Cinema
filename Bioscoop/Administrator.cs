using System;
using System.Collections.Generic;

public static class Administrator
{
    private static void PressEnter()
    {
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }

    private static void ErrorCode()
    {
        Console.WriteLine("Error, only use the numbers from the option menu");
    }

    private static void ListMoviesAsOptions()
    {
        List<Movie> movies = Data.LoadMovies();
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            Console.WriteLine("Choose a movie to see more information or type 'x' to go back.\n");
            int index = 0;
            foreach (Movie movie in movies)
            {
                Console.WriteLine(index.ToString() + ") " + movie.GetMovieTitle());
                index++;
            }
            string option = Console.ReadLine();
            int x = 0;
            if (Int32.TryParse(option, out x))
            {
                // Test if in bounds of List
                if (x >= 0 && x < movies.Count)
                {
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
                    Console.WriteLine("Please choose a number between 0 and " + movies.Count.ToString() + ".");
                }
                PressEnter();
            }
            else
            {
                if (option.ToLower() != "x")
                {
                    ErrorCode();
                    PressEnter();
                }
                else
                {
                    // go back
                    loop = false;
                }
            }
        }
        
        

    }

    public static void Menu()
    {
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            // Present the menu options
            Console.WriteLine("Welcome to the admin part");
            Console.WriteLine("1) View all movies");
            Console.WriteLine("2) Add a movie");
            Console.WriteLine("3) Edit a movie");
            Console.WriteLine("4) Remove a movie");
            Console.WriteLine("5) Exit the admin part and go back to the main menu");
            // Prompt the user to choose
            switch (Console.ReadLine())
            {
                case "1":
                    ListMoviesAsOptions();
                    continue;
                case "2":
                    Console.WriteLine("Option 2");
                    continue;
                case "3":
                    Console.WriteLine("Option 3");
                    continue;
                case "4":
                    Console.WriteLine("Option 4");
                    continue;
                case "5":
                    Console.WriteLine("Option 5");
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
