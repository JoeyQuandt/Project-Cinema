
using System;

public class Menu
{
    public void menu()
    {
        // Create dummy actor objects
        Actor joey = new Actor("Joey", "Dummy");
        Actor thomas = new Actor("Thomas", "Dummy");
        // Put actors in array
        Actor[] actors = { joey, thomas };
        // Make movie object
        Movie movie = new Movie("Joey's revenge", "A movie about the evil man Joey getting his revenge on Fransesco", 99, actors, DateTime.Now);
        Movie TheRevenge = new Movie("Alexandro's Revenge", "A movie about the villain alexandro who wreaks havoc on the small town of Rotterdamdorp.", 180, actors, DateTime.Now);
        Movie CoryintheHouse = new Movie("Cory in the House", "A comedy film about a young boy whose father becomes the president of the United States all of a sudden.", 220, actors, DateTime.Now);
        // Make ticket object
        //Make ticket object
        Ticket test = new Ticket(TheRevenge, DateTime.Now, 18, new Room("Room 1", 10), 14);
        // Write the movie details from the movie object in the console
        Console.WriteLine(TheRevenge.GetMovieDetails());
        // Welcome text and menu text
        Console.Clear();
        Console.WriteLine("=====Welcome to Jack Cinema.=====");
        Console.WriteLine("This cinema has 8 rooms with the latest movies releases. The Cinema is everday open between 8:30-22:00");
        Console.WriteLine("Type 1 for the movie availability");
        Console.WriteLine("Type 2 to buy an ticket");
        Console.WriteLine("Type 3 for the user account information");
        Console.Write("\r\nSelect an option: ");
        if (Console.ReadLine() == "1")
        {
            Console.WriteLine("Here you can see all the available movies");
            Console.WriteLine("=========================================");
            Console.WriteLine(movie.GetMovieDetails());
            Console.WriteLine("=========================================");
            Console.WriteLine(TheRevenge.GetMovieDetails());
            Console.WriteLine("=========================================");
            Console.WriteLine(CoryintheHouse.GetMovieDetails());
            Console.WriteLine("=========================================");
        }
        else if (Console.ReadLine() == "2")
        {
            Console.WriteLine("Here you can buy tickets and can you see what the prices are");
            Console.WriteLine("=========================================");
            Console.WriteLine(test.GetTicketDetails());
            Console.WriteLine("=========================================");

        }

        else if (Console.ReadLine() == "3")
        {
            Console.WriteLine("Here can you register or login");
        }
        else
        {
            Console.WriteLine("Please put in the correct number");
        }
    }
    
}