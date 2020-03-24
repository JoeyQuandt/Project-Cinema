using System;

public static class Administrator
{
    private static void PressEnter()
    {
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }

    private static void ErrorCode()
    {
        Console.Clear();
        Console.WriteLine("Error, only use the numbers from the option menu");
        PressEnter();
    }

    public static void Menu()
    {
        bool loop = true;
        while (loop)
        {
            // Present the menu options
            Console.WriteLine("Welcome to the admin part");
            Console.WriteLine("1) View all movies");
            Console.WriteLine("2) Add a movie");
            Console.WriteLine("3) Edit a movie");
            Console.WriteLine("4) Remove a movie");
            Console.WriteLine("5) Exit the admin part and go back to the main menu");
            // Prompt the user to choose
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Option 1");
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
                    Console.WriteLine("\nPlease enter a valid option\n");
                    PressEnter();
                    continue;
            }
        }
       

    }
}
