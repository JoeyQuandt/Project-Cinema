
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
    public void ErrorMessage()
    {
        Console.Clear();
        Console.WriteLine("Error, only use the numbers from the option menu");
        PressEnter();
    }
    //Movie Information
    public void ShowMovieDetails()
    {
        Console.Clear();

        foreach (Movie movie in Data.LoadMovies())
        {
            Console.WriteLine(movie.GetMovieDetails()+"\n==============");
        }
        PressEnter();
    }
    //Ticket Information
    public void ShowTicketDetails()
    {
        Console.Clear();
        Console.WriteLine("=====Ticket Information=====");
        Console.WriteLine("Here you can see all the information about prices\nFor Adults(18 years and older): $20\nFor Children(17 years and younger): $15");
        PressEnter();
    }

    // A function made to be able to error handle inputs where you want an integer as result.
    // Parameters are for a message and a limit 
    public int IntegerInput(string Message, int Limit = 100)
    {
        while (true)
        {
            Console.WriteLine(Message);
            string input = Console.ReadLine();
            // This function tries to make / parse the input to an integer, if it succeeds you get an integer called "ParsedInput".
            // If it fails to parse the input to an integer it will run the else.
            if (Int32.TryParse(input, out int ParsedInput))
            { 
                if (ParsedInput < 1 || ParsedInput > Limit)
                {
                    Console.WriteLine($"Enter a value between 1 and {Limit}.");
                }
                else
                {
                    return ParsedInput;
                }
            }
            else
            {
                Console.WriteLine("Please enter a different value.");
            }
        }
    }


    //List<Reservation>
    public int MakeReservation()
    {
        // Makes Lists from the data in the JSON
        List<Room> RoomList = Data.LoadRooms();
        List<Movie> MovieList = Data.LoadMovies();
        List<MovieTime> MovieTimesList = Data.LoadMovieTimes();
        MovieTimesList.Sort((listA, ListB) => DateTime.Compare(listA.date, ListB.date));
        // Sorts the MovieTimes
        List<MovieTime> SortedMovieTimes = new List<MovieTime>();
        // Counter for items removed
        int Removed = 0;
        for (int x = 1; x < MovieTimesList.Count; x++)
        {
            // Checks if this movie has aired already, if it has it will not add it to this list.
            if(DateTime.Compare(MovieTimesList[x].GetDate(), DateTime.Now) == 1)
            {
                SortedMovieTimes.Add(MovieTimesList[x]);
            } else
            {
                Removed++;
            }
        }
        // A for loop that shows all the movie titles that are in the database. And also checks if a movie is full or not
        for (int x = 1; x < SortedMovieTimes.Count + 1; x++)
        {
            if (SortedMovieTimes[x -1].GetRoom().IsFull() == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(x + ") " + SortedMovieTimes[x -1].GetMovieTimeDetails());
                Console.ForegroundColor = ConsoleColor.Gray;
            } else
            {
                Console.WriteLine(x + ") " + SortedMovieTimes[x -1].GetMovieTimeDetails());
            }
        }
        int MovieNumber = IntegerInput("Enter the number of the movie you want to reserve for.", SortedMovieTimes.Count);

        if (SortedMovieTimes[MovieNumber-1].GetRoom().IsFull())
        {
            Console.WriteLine("Sorry, this movie has no more room left. Please select a different movie.");
            MakeReservation();
        }
        else
        {
            Console.WriteLine($"Confirm to place a reservation for {SortedMovieTimes[MovieNumber-1].GetMovie().GetMovieTitle()}\ny/n");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    int TicketAmount = IntegerInput("Enter the amount of tickets you want", SortedMovieTimes[MovieNumber-1].GetRoom().GetAvailableSeats());
                    int AdultTicketAmount = IntegerInput("How many adult tickets do you want?", TicketAmount);
                    int ChildTicketAmount = TicketAmount - AdultTicketAmount;
                    // For when more types of tickets will be added
                    // int childTicketAmount = Integer_input("How many child tickets do you want?", ticketAmount - adultTicketAmount);

                    List<Ticket> TicketListReservation =  new List<Ticket>();
                    List<Ticket> TicketList = Data.LoadTickets();
                    int SeatNumber = SortedMovieTimes[MovieNumber-1].GetRoom().GetTakenSeats();
                    for (int x = 0; x < AdultTicketAmount; x++)
                    {
                        TicketList.Add(new Ticket(SeatNumber, "Adult"));
                        TicketListReservation.Add(new Ticket(SeatNumber, "Adult"));
                        SeatNumber += 1;
                    }
                    for (int x = 0; x < ChildTicketAmount; x++)
                    {
                        TicketList.Add(new Ticket(SeatNumber, "Child"));
                        TicketListReservation.Add(new Ticket(SeatNumber, "Child"));
                        SeatNumber += 1;
                    }

                    //Herress
                    Console.WriteLine("\nThe free seats have a green display and the taken seats are red.\nPlease enter your seats as following: 45 or 223345.\n");
                    Span<int> storage = stackalloc int[40];
                    int zero = 11;
                    foreach (ref int item in storage)
                    {
                        if (item == ChosenSeats)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        item = zero++;
                        Console.Write($"[{item}]");
                        if (item == 20 || item == 30 || item == 40 || item == 50)
                        {
                            Console.WriteLine("\n");
                        }
                        if (item == 15 || item == 25 || item == 35 || item == 45)
                        {
                            Console.Write("     ");
                        }
                    }
                    int ChosenSeats = IntegerInput("Which seats do you want?");


                    // Adds Reservation to JSON file.
                    MovieTimesList[MovieNumber+Removed].GetRoom().FillSeats(TicketAmount);
                    string SerializedMovieTimesList = JsonConvert.SerializeObject(MovieTimesList, Formatting.Indented);
                    File.WriteAllText(@"../../../data/movieTimesData.json", SerializedMovieTimesList);
                    Console.WriteLine("STORED!");
                    // Adds Tickets to JSON file
                    string SerializedTicketList = JsonConvert.SerializeObject(TicketList, Formatting.Indented);
                    File.WriteAllText(@"../../../data/ticketData.json", SerializedTicketList);
                    Console.WriteLine("STORED!");
                    // Adds Reservation to JSON file.
                    List<Reservation> ReservationList = Data.LoadReservations();
                    Reservation Reservation = new Reservation("Lennert", TicketListReservation, MovieTimesList[MovieNumber + Removed]);
                    ReservationList.Add(Reservation);
                    string SerializedReservationList = JsonConvert.SerializeObject(ReservationList, Formatting.Indented);
                    File.WriteAllText(@"../../../data/reservationData.json", SerializedReservationList);
                    Console.WriteLine("STORED!");

                    return 0;

                case "n":
                    MakeReservation();
                    return 0;

                default:
                    MakeReservation();
                    return 0;
            }
        }
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
                ShowMovieDetails();
                return true;
            case "2":
                ShowTicketDetails();
                return true;
            case "3":
                Login_information();
                return true;
            case "4":
                return false;
            case "5":
                MakeReservation();
                return true;
            default:
                ErrorMessage();
                return true;
        }

    }
}
