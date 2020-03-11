
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
        Data data = new Data();
        foreach (Movie movie in data.LoadMovies())
        {
            Console.WriteLine(movie.GetMovieDetails());
        }
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

    // Fucntionality for logging in
    public void Login_information()
    {
        // Prepare variables
        Data data = new Data();
        User authorizedUser = null;
        bool loginSuccesfull = false;
        bool loginLoop = true;

        // Loop while user wants to try to enter a user account
        while (loginLoop)
        {
            // Let the user enter credentials 
            Console.Clear();
            Console.WriteLine("Login\n");
            Console.WriteLine("Username: ");
            string un = Console.ReadLine();
            Console.WriteLine("Password: ");
            string pw = Console.ReadLine();


            // Loop over all the users from the JSON and check if one has the given credentials
            foreach (User user in data.LoadUsers())
            {
                if (user.VerifyLogin(un, pw) && !loginSuccesfull)
                {
                    loginSuccesfull = true;
                    authorizedUser = user;
                }

            }

            // If login is successfull, let the user know. Otherwise let them know they entered the wrong info.
            if (loginSuccesfull)
            {
                // Login successfull, let the user know and let them return to the menu
                Console.Clear();
                Console.WriteLine("Log in succesfull");
                Console.WriteLine("Welcome, " + authorizedUser.GetFirstName());
                loginLoop = false;
                PressEnter();
            }
            else
            {
                // Wrong credentials. Prompt the user to try again or leave.
                Console.Clear();
                Console.WriteLine("Wrong username or password");
                Console.WriteLine("1. Try again");
                Console.WriteLine("2. Go back");
                string option = Console.ReadLine();
                if(option == "2")
                {
                    loginLoop = false;
                }
            }
        }
    }
}
