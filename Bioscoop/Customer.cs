using System;

public static class Customer
{
	// Function to ask the user to press enter to continue
	public static void PressEnter()
	{
		Console.WriteLine("Press Enter to continue");
		Console.ReadLine();
	}

	// Function to give an error
	private static void ErrorCode()
	{
		Console.Write("Error, only use the numbers from the options menu... ");
	}

	// Function to show reservations
	private static void ShowReservations()
	{
		Console.Clear();
		foreach (Reservation reservation in Data.LoadReservations())
		{
			Console.WriteLine(reservation.GetReservationDetails() + "\n");
		}
		PressEnter();
	}

	// Function to make a reservation
	private static void MakeReservation()
	{
		Menu.MakeReservation();
	}

	// Function to change a reservation
	private static void ChangeReservation()
	{

	}

	// Function to cancel a reservation
	private static void CancelReservation()
	{

	}

	// Function for the customer menu
	public static void CustomerMenu()
	{
		bool isInMenu = true;
		while (isInMenu)
		{
			Console.Clear();
			// Show options for the customer
			Console.WriteLine("Welcome " + Menu.authorizedUser.GetFirstName() + " " + Menu.authorizedUser.GetLastName() + "!" );
			Console.WriteLine("1) View all reservations");
			Console.WriteLine("2) Make a reservation");
			Console.WriteLine("3) Change a reservation");
			Console.WriteLine("4) Cancel a reservation");
			Console.WriteLine("5) Log out");

			switch (Console.ReadLine())
			{
				case "1":
					ShowReservations();
					continue;
				case "2":
					MakeReservation();
					continue;
				case "3":
					ChangeReservation();
					continue;
				case "4":
					CancelReservation();
					continue;
				case "5":
					isInMenu = false;
					continue;
				default:
					ErrorCode();
					PressEnter();
					continue;
			}
		}
	}
}
