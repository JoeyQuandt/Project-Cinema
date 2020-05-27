
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Menu
{
    public static User authorizedUser = null;

    //Press enter to return to the main menu
    public static void PressEnter()
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
    public static void ShowMovieDetails()
    {
        Console.Clear();
        Console.WriteLine("This is the schedule of the movies. The movies that are colored in red are either full or unavailable.\n");
        foreach (MovieTime movie in Data.LoadMovieTimes())
        {
            if (movie.GetRoom().IsFull())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(movie.GetMovieTimeDetails() + "\n==============");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(movie.GetMovieTimeDetails() + "\n==============");
            }

        }
        PressEnter();
    }
    public static void ShowAvailableMovies()
    {
        Console.Clear();
        Console.WriteLine("These are the movies that are currently available.\n");
        foreach (Movie movie in Data.LoadMovies())
        {
            
            Console.WriteLine(movie.GetMovieDetails() + "\n==============");
        }
        PressEnter();
    }
    //Ticket Information
    public static void ShowTicketDetails()
    {
        Console.Clear();
        Console.WriteLine("=====Ticket Information=====");
        Console.WriteLine("Here you can see all the information about prices\nFor Adults(18 years and older): $20\nFor Children(17 years and younger): $15");
        PressEnter();
    }

    // A function made to be able to error handle inputs where you want an integer as result.
    // Parameters are for a message and a limit 
    public static int IntegerInput(string Message, int Limit = 100, int LowLimit = 1)
    {
        while (true)
        {
            Console.WriteLine(Message);
            string input = Console.ReadLine();
            // This function tries to make / parse the input to an integer, if it succeeds you get an integer called "ParsedInput".
            // If it fails to parse the input to an integer it will run the else.
            if (Int32.TryParse(input, out int ParsedInput))
            { 
                if (ParsedInput < LowLimit || ParsedInput > Limit)
                {
                    Console.WriteLine($"Enter a value between {LowLimit} and {Limit}.");
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
    public static int MakeReservation()
    {
        List<Consumption> ConsumptionList = Data.LoadConsumptions();
        string[] allergies = new string[] { "peanuts", "sweetcorn" };
        Consumption consumption = new Consumption("Popcorn", "Crunchy popcorn", "Medium", allergies);
        ConsumptionList.Add(consumption);
        string SerializedConsumptionList = JsonConvert.SerializeObject(ConsumptionList, Formatting.Indented);
        File.WriteAllText(@"../../../data/consumptionData.json", SerializedConsumptionList);
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
                    int AdultTicketAmount = IntegerInput("How many adult tickets do you want?", SortedMovieTimes[MovieNumber - 1].GetRoom().GetAvailableSeats());
                    int ChildTicketAmount = IntegerInput("How many child tickets do you want?", SortedMovieTimes[MovieNumber - 1].GetRoom().GetAvailableSeats() - AdultTicketAmount, 0);
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

                    // Adds Reservation to JSON file.
                    MovieTimesList[MovieNumber+Removed].GetRoom().FillSeats(AdultTicketAmount + ChildTicketAmount);
                    string SerializedMovieTimesList = JsonConvert.SerializeObject(MovieTimesList, Formatting.Indented);
                    File.WriteAllText(@"../../../data/movieTimesData.json", SerializedMovieTimesList);

                    // Adds Tickets to JSON file
                    string SerializedTicketList = JsonConvert.SerializeObject(TicketList, Formatting.Indented);
                    File.WriteAllText(@"../../../data/ticketData.json", SerializedTicketList);

                    // Adds Reservation to JSON file.
                    List<Reservation> ReservationList = Data.LoadReservations();
                    Reservation Reservation = new Reservation(authorizedUser.GetFirstName() + " " + authorizedUser.GetLastName(), TicketListReservation, MovieTimesList[MovieNumber + Removed]);
                    ReservationList.Add(Reservation);
                    string SerializedReservationList = JsonConvert.SerializeObject(ReservationList, Formatting.Indented);
                    File.WriteAllText(@"../../../data/reservationData.json", SerializedReservationList);
                    Console.WriteLine($"The cost of {AdultTicketAmount} adult tickets : ${AdultTicketAmount * 20}\nThe cost of {ChildTicketAmount} child tickets : ${ChildTicketAmount * 15}\nTotal cost :  ${AdultTicketAmount*20 + ChildTicketAmount*15}");
                    PressEnter();
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
            string pw = "";
            // Hide password input
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pw += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pw.Length > 0)
                    {
                        pw = pw.Substring(0, (pw.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } 

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
                    Administrator.AdminMenu();
                    loginLoop = false;
                } else
                {
                    Customer.CustomerMenu();
                    loginLoop = false;
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
        Console.WriteLine("=====Welcome to Jack Cinema.=====\nHere you can see information of movies and see the prices for the tickets.\nLogin to place a reservation.\n");

        if (loginSuccesfull)
        {
            Console.WriteLine("Welcome, " + authorizedUser.GetFirstName());
        }
        Console.WriteLine("1) Show movie times and availability");
        Console.WriteLine("2) Show list of current available movies");
        Console.WriteLine("3) Show ticket information");
        Console.WriteLine("4) Log in");
        Console.WriteLine("5) Register account");
        Console.WriteLine("6) Exit");

        Console.Write("\r\nSelect an option: ");
        //switch checking which number is pressed
        switch (Console.ReadLine())
        {
            case "1":
                ShowMovieDetails();
                return true;
            case "2":
                ShowAvailableMovies();
                return true;
            case "3":
                ShowTicketDetails();
                return true;
            case "4":
                Login_information();
                return true;
            case "5":
                Register_information();
                return true;
            case "6":
                return false;
            default:
                ErrorMessage();
                return true;
        }

    }

    private void Register_information()
    {
        // TODO: Change this to registering
        // Prepare variables
        bool registerFailed = false;
        bool registerLoop = true;

        // Loop while user wants to try to enter a user account
        while (registerLoop)
        {
            // Reset failed variable
            registerFailed = false;

            // Let the user enter credentials 
            Console.Clear();
            Console.WriteLine("=====Register=====\n");
            Console.WriteLine("Username: ");
            string un = Console.ReadLine();
            Console.WriteLine("Password: ");
            string pw = "";
            // Hide password input
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pw += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pw.Length > 0)
                    {
                        pw = pw.Substring(0, (pw.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("First Name: ");
            string fn = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string ln = Console.ReadLine();

            // Loop over all the users from the JSON and check if one has the given credentials
            foreach (User user in Data.LoadUsers())
            {
                if (user.GetUsername() == un)
                {
                    registerFailed = true;
                }

            }

            // If registering failed, show error
            if (registerFailed)
            {
                Console.WriteLine("Someone has that username");
                Console.WriteLine("Press enter to try again");
                Console.ReadLine();

            }
            else
            {
                // Success
                Console.Clear();
                Console.WriteLine("Successfully registered!");
                Console.WriteLine($"Welcome {fn}!");
                Console.WriteLine();
                PressEnter();
                registerLoop = false;

                // Add user to JSON
                List<User> list = Data.LoadUsers();
                list.Add(new User(un, pw, fn, ln, "user"));
                var SerializedList = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(@"../../../data/userData.json", SerializedList); 
            }
        }
    }
}
