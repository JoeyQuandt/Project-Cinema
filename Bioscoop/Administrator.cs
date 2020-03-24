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
        Console.Clear();
        foreach(Movie movie in movies)
        {
            Console.WriteLine(movie.GetMovieTitle());
            Console.WriteLine(movie.GetMovieDescription());
            Console.WriteLine(movie.GetMovieDuration().ToString() + " minutes");
            Console.WriteLine("");
        }
        PressEnter();
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
