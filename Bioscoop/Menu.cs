
using System;

public class Menu
{   
    //Press enter to return to the main menu
    public void PressEnter()
    {
        Console.WriteLine("Press Enter to return to Main Menu");
        var x = Console.ReadLine();
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
        Data data = new Data();
        foreach (Movie movie in data.LoadMovies())
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
            Console.WriteLine("=====Login=====\n");
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

    //Fuctionality for the main menu
    public bool MainMenu()
    {
        Data data = new Data();
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
            default:
                Error_code();
                return true;
        }

    }
}
