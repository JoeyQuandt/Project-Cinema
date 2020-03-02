using System;

namespace Bioscoop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create dummy actor objects
            Actor joey = new Actor();
            Actor thomas = new Actor();
            // Put actors in array
            Actor[] actors = { joey, thomas };

            // Make movie object
            Movie movie = new Movie("Joey's revenge", "A movie about the evil man Joey getting his revenge on Fransesco", 99, actors, DateTime.Now);

            // Write the movie details from the movie object in the console
            Console.WriteLine(movie.getMovieDetails());
        }
    }
}
