
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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

    public List<Room> Make_roomlist()
    {
        var RoomList = new List<Room>();
        foreach (Room room in Data.LoadRooms())
        {
            RoomList.Add(room);
        }
        return RoomList;
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
        var RoomList = Make_roomlist();
        var MovieList = Make_movielist();

        //Console.WriteLine(MovieLists[1]);
        for (int x = 1; x < MovieList.Count + 1; x++)
        {
            Console.WriteLine(x + ") " + MovieList[x - 1].GetMovieTitle());
        }

        int MovieNumber = integer_Input("Enter the number of the movie you want to reserve for.", MovieList.Count);
        Console.WriteLine("Confirm to place a reservation for " + MovieList[MovieNumber - 1].GetMovieTitle() + "\ny/n");
        switch (Console.ReadLine().ToLower())
        {
            case "y":
                DateTime timeReservation = DateTime.Now;


                // var list = JsonConvert.DeserializeObject<List<Ticket>>(@"../../../data/ticketData.json");
                // list.Add(new Ticket(MovieList[MovieNumber - 1], timeReservation, RoomList[0], 1, "Adult"));
                // JsonConvert.SerializeObject(list, Formatting.Indented);

                int ticketAmount = integer_Input("Enter the amount of tickets you want");
                int adultTicketAmount = integer_Input("How many adult tickets do you want?", ticketAmount);
                int childTicketAmount = integer_Input("How many child tickets do you want?", ticketAmount - adultTicketAmount);

                Ticket test = new Ticket(MovieList[MovieNumber - 1], timeReservation, RoomList[0], 1, "Adult");
                string storeticket = JsonConvert.SerializeObject(test, Formatting.Indented);
                File.AppendAllText(@"../../../data/ticketData.json", storeticket + ",\n");
                Console.WriteLine("Stored!");

                Reservation newReservation = new Reservation("Ingelogde User", timeReservation, ticketAmount, test);
                string saveReservation = JsonConvert.SerializeObject(newReservation, Formatting.Indented);
                File.AppendAllText(@"../../../data/reservationData.json", saveReservation + ",\n");
                Console.WriteLine("Thank you for your reservation!");
                PressEnter();


                return 0;

            case "n":
                Make_reservation();
                return 0;

            default:
                Make_reservation();
                return 0;
        }

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
                if (authorizedUser.GetRole() == "admin")
                {
                    Administrator.Menu();
                    loginLoop = false;
                } else
                {
                    Console.WriteLine("Log in succesfull");
                    Console.WriteLine("Welcome, " + authorizedUser.GetFirstName());
                    loginLoop = false;
                    PressEnter();
                }
                
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
