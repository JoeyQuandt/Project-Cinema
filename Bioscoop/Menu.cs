
using System;

public class Menu
{   

    public Actor[] GetActors()
    {
        // Create dummy actor objects
        Actor joey = new Actor("Joey", "Dummy");
        Actor thomas = new Actor("Thomas", "Dummy");
        // Put actors in array
        Actor[] actors = { joey, thomas };
        return actors;
    }

    public void PressEnter()
    {
        Console.WriteLine("\r\nPress Enter to return to Main Menu");
        var x = Console.ReadLine();
    }

    public void Error_code()
    {
        Console.Clear();
        Console.WriteLine("Error, only use the numbers from the option menu");
        PressEnter();
    }

    public Movie[] Getmovies()
    {
        Movie movie = new Movie("110d3232-edeb-4d5e-b544-7b3fa52b8924", "Joey's revenge", "A movie about the evil man Joey getting his revenge on Fransesco", 99, GetActors(), DateTime.Now);
        Movie TheRevenge = new Movie("00e94834-8460-4667-9ee1-60bd8371c710", "Alexandro's Revenge", "A movie about the villain alexandro who wreaks havoc on the small town of Rotterdamdorp.", 180, GetActors(), DateTime.Now);
        Movie CoryintheHouse = new Movie("f8afc815-bdef-4785-8105-c3aa4f03112a", "Cory in the House", "A comedy film about a young boy whose father becomes the president of the United States all of a sudden.", 220, GetActors(), DateTime.Now);
        Movie[] movies = { movie, TheRevenge, CoryintheHouse };
        return movies;
    }

    public void bar()
    {
        Console.WriteLine("=========================================");
    }

    public void Movie_availability()
    {
        Console.Clear();
        Console.WriteLine("Here you can see all the available movies");
        bar();
        Console.WriteLine(Getmovies()[0].GetMovieDetails());
        bar();
        Console.WriteLine(Getmovies()[1].GetMovieDetails());
        bar();
        Console.WriteLine(Getmovies()[2].GetMovieDetails());
        bar();
        PressEnter();
    }
    public bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("=====Welcome to Jack Cinema.=====");
        Console.WriteLine("1) For movie availability");
        Console.WriteLine("2) For ticket information");
        Console.WriteLine("3) For login  information");
        Console.WriteLine("4) Exit");
        Console.Write("\r\nSelect an option: ");
        //Hier kijkt de programma naar welke pagina moet.
        switch (Console.ReadLine())
        {
            case "1":
                Movie_availability();
                return true;
            case "2":
                Ticket_information();
                return true;
            case "3":
                Login_information();
                return true;
            case "4":
                return false;
            default:
                Error_code();
                return true;
        }
        
    }

    //Hier komt de ticket informatie te staan
    public void Ticket_information()
    {
        Console.Clear();
        Console.WriteLine("=====Ticket Information=====");
        Console.WriteLine("Here you can see all the information about prices\nFor Adults(18 years and older): $20\nFor Children(17 years and younger): $15");
        PressEnter();
    }

    //Hier komt de login informatie te staan
    public void Login_information()
    {
        Console.Clear();
        Console.WriteLine("login information");
        PressEnter();
    }
}
