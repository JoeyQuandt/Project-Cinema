
using System;
using System.Collections.Generic;

public class Menu
{   
    //Press enter to return to the main menu
    public void PressEnter()
    {
        Console.WriteLine("Press Enter to return to Main Menu");
        Console.ReadLine();
    }
    //Error function
    public void Error_code()
    {
        Console.Clear();
        Console.WriteLine("Error, only use the numbers from the option menu");
        PressEnter();
    }
    //Movie Information
    public void Movie_information()
    {
        Console.Clear();

        foreach (Movie movie in Data.LoadMovies())
        {
            
            Console.WriteLine(movie.GetMovieDetails()+"\n==============");
        }

        PressEnter();
    }
    //Ticket Information
    public void Ticket_information()
    {
        Console.Clear();
        Console.WriteLine("=====Ticket Information=====");
        Console.WriteLine("Here you can see all the information about prices\nFor Adults(18 years and older): $20\nFor Children(17 years and younger): $15");
        PressEnter();
    }
    // Makes a list of all the movies.
    public List<Movie> Make_movielist()
    {
        var MovieList = new List<Movie>();
        foreach (Movie movie in Data.LoadMovies())
        {
            MovieList.Add(movie);
        }
        return MovieList;
    }

    // Error handles inputs and casts them to integers.
    public int integer_Input(string message, int limit = 1000)
    {
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            //var intMovieNumber = Int32.Parse(movieNumber);
            if (Int32.TryParse(input, out int castedInput))
            { 
                if (castedInput < 1 && castedInput > limit)
                {
                    Console.WriteLine("Enter a value between 1 and " + limit);
                }
                else
                {

                    return castedInput;
                }
            }
            else
            {
                //It failed, do other stuff
                Console.WriteLine("Enter a different value");
            }
        }
    }
    //List<Reservation>
    public int Make_reservation()
    {
        var MovieList = Make_movielist();

        //Console.WriteLine(MovieLists[1]);
        for (int x = 1; x < MovieList.Count + 1; x++)
        {
            Console.WriteLine(x + ") " + MovieList[x - 1].GetMovieTitles());
        }

        int MovieNumber = integer_Input("Enter the number of the movie you want to reserve for.", MovieList.Count);
        Console.WriteLine("Confirm to place a reservation for " + MovieList[MovieNumber - 1].GetMovieTitles() + "\nY/N" );
        switch (Console.ReadLine())
        {
            case "Y":
                int ticketAmount = integer_Input("Enter the amount of tickets you want");

                int adultTicketAmount = integer_Input("How many adult tickets do you want?", ticketAmount);

                int childTicketAmount = integer_Input("How many child tickets do you want?", ticketAmount - adultTicketAmount);

                return 0;
            case "N":
                Make_reservation();
                return 0;
        }



        Console.WriteLine();
        PressEnter();
        return 0;
    }



    // Functionality for logging in
    public void Login_information()
    {
        // Prepare variables
        User authorizedUser = null;
        bool loginSuccesfull = false;
        bool loginLoop = true;

        // Loop while user wants to try to enter a user account
        while (loginLoop)
        {
            // Let the user enter credentials 
            Console.Clear();
            Console.WriteLine("=====Login=====\n");
            Console.WriteLine("Username: ");
            string un = Console.ReadLine();
            Console.WriteLine("Password: ");
            string pw = Console.ReadLine();


            // Loop over all the users from the JSON and check if one has the given credentials
            foreach (User user in Data.LoadUsers())
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

    //Fuctionality for the main menu
    public bool MainMenu()
    {
        //Data data = new Data();
        User authorizedUser = null;
        bool loginSuccesfull = false;
        bool loginLoop = true;
        //menu options
        Console.Clear();
        Console.WriteLine("=====Welcome to Jack Cinema.=====");
        if (loginSuccesfull)
        {
            Console.WriteLine("Welcome, " + authorizedUser.GetFirstName());
        }
        Console.WriteLine("1) For movie availability");
        Console.WriteLine("2) For ticket information");
        Console.WriteLine("3) For login  information");
        Console.WriteLine("4) Exit");
        Console.WriteLine("5) Place reservation");
        
        Console.Write("\r\nSelect an option: ");
        //switch checking which number is pressed
        switch (Console.ReadLine())
        {
            case "1":
                Movie_information();
                return true;
            case "2":
                Ticket_information();
                return true;
            case "3":
                Login_information();
                return true;
            case "4":
                return false;
            case "5":
                Make_reservation();
                return true;
            default:
                Error_code();
                return true;
        }

    }
}
