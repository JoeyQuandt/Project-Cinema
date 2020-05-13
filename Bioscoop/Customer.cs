using System;
using System.Collections.Generic;

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
		Console.Write("Error, only use the given options...\n");
	}

	// Function to show reservations
	private static void ShowReservations()
	{
		string currentUser = Menu.authorizedUser.GetFirstName() + " " + Menu.authorizedUser.GetLastName();
		int reservationCount = 0;
		Console.Clear();
		Console.WriteLine("<< Your reservations >>\n");
		foreach (Reservation reservation in Data.LoadReservations())
		{
			if (reservation.GetReservationUser() == currentUser)
			{
				Console.WriteLine(reservation.GetReservationDetails() + "\n");
				reservationCount++;
			}
		}

		if (reservationCount == 0)
		{
			Console.WriteLine("No reservations found\n");
		} 
		else
		{
			Console.WriteLine("Total reservations: " + reservationCount + "\n");
		}

		PressEnter();
	}

	// Function to make a reservation
	private static void MakeReservation()
	{
		Menu.MakeReservation();
	}

	// Function to change a reservation
	private static void EditReservation()
	{
		string currentUser = Menu.authorizedUser.GetFirstName() + " " + Menu.authorizedUser.GetLastName();
		List<Reservation> reservations = Data.LoadReservations();
		List<Reservation> customerReservations = new List<Reservation>();
		bool isInEditMode = true;
		while (isInEditMode)
		{
			Console.Clear();
			Console.WriteLine("<< Cancel a reservation >>\n");

			int reservationCount = 0;
			foreach (Reservation reservation in reservations)
			{
				if (reservation.GetReservationUser() == currentUser)
				{
					reservationCount++;
					Console.WriteLine(reservationCount.ToString() + ") " + reservation.GetReservationDetails());
					customerReservations.Add(reservation);
				}
			}

			if (reservationCount == 0)
			{
				Console.WriteLine("\nNo reservations found\nType 'x' to go back");
			}
			else
			{
				Console.WriteLine("\nEnter the number of the reservation to edit it.\nType 'x' to go back");
			}

			// TO DO: Zorg ervoor dat je niet 2x een input moet doen om terugkoppelling te krijgen van de console
			string userInput = Console.ReadLine();
			int x = 0;
			if (Int32.TryParse(userInput, out x))
			{
				if (x > 0 && x <= customerReservations.Count)
				{
					Console.WriteLine("Enter your new adult ticket total");
					int adultTickets = int.Parse(Console.ReadLine());
					Console.WriteLine("Enter your new child ticket total");
					int childTickets = int.Parse(Console.ReadLine());
					int totalTickets = adultTickets + childTickets;

					// Show the new reservation
					Console.WriteLine("\nAre you sure? (y/n)");
					switch (Console.ReadLine().ToLower())
					{
						// Edit reservation
						case "y":
							// TO DO: Write to json
							Reservation reservation = customerReservations[x - 1];
							Console.WriteLine("You've succesfully changed the reservation!");
							Console.WriteLine("\n* New reservation: *\n" + reservation.GetReservationDetails());
							PressEnter();
							continue;
						// Don't edit reservation
						case "n":
							Console.WriteLine("You didn't changed the reservation.");
							PressEnter();
							continue;
						// Give an error
						default:
							ErrorCode();
							PressEnter();
							continue;
					}
				}
				else
				{
					if (reservationCount != 0)
					{
						Console.WriteLine("Enter a number from 1 to " + reservationCount);
						PressEnter();
					}
				}
			}
			else
			{
				if (Console.ReadLine().ToLower() != "x")
				{
					ErrorCode();
					PressEnter();
				}
				else
				{
					isInEditMode = false;
				}
			}
		}
	}

	// Function to cancel a reservation
	private static void RemoveReservation()
	{
		string currentUser = Menu.authorizedUser.GetFirstName() + " " + Menu.authorizedUser.GetLastName();
		List<Reservation> reservations = Data.LoadReservations();
		List<Reservation> customerReservations = new List<Reservation>();
		bool isInRemoveMode = true;
		while(isInRemoveMode)
		{
			Console.Clear();
			Console.WriteLine("<< Cancel a reservation >>\n");

			int reservationCount = 0;
			foreach(Reservation reservation in reservations)
			{
				if (reservation.GetReservationUser() == currentUser)
				{
					reservationCount++;
					Console.WriteLine(reservationCount.ToString() + ") " + reservation.GetReservationDetails());
					customerReservations.Add(reservation);
				} 
			}

			if (reservationCount == 0)
			{
				Console.WriteLine("\nNo reservations found\nType 'x' to go back");
			}
			else
			{
				Console.WriteLine("\nEnter the number of the reservation to cancel it.\nType 'x' to go back");
			}

			// TO DO: Zorg ervoor dat je niet 2x een input moet doen om terugkoppelling te krijgen van de console
			string userInput = Console.ReadLine();
			int x = 0;
			if (Int32.TryParse(userInput, out x))
			{
				if (x > 0 && x <= customerReservations.Count)
				{
					// Check is user really want to remove the reservation
					Console.WriteLine("Are you sure? y/n");
					switch(Console.ReadLine().ToLower())
					{
						// Remove reservation
						case "y":
							Reservation reservation = customerReservations[x - 1];
							// TODO: Delete reservation in JSON
							Console.WriteLine("You succesfully cancelled your reservation\n" + reservation.GetReservationDetails());
							PressEnter();
							continue;
						// Don't remove reservation
						case "n":
							Console.WriteLine("You did not cancel the reservation");
							PressEnter();
							continue;
						// Give an error
						default:
							ErrorCode();
							PressEnter();
							continue;
					}
				}
				else 
				{
					if (reservationCount != 0)
					{
						Console.WriteLine("Enter a number from 1 to " + reservationCount);
						PressEnter();
					}
				}
			}
			else
			{
				if (Console.ReadLine().ToLower() != "x")
				{
					ErrorCode();
					PressEnter();
				}
				else
				{
					isInRemoveMode = false;
				}
			}
		}

	}

	// Function for the customer menu
	public static void CustomerMenu()
	{
		string currentUser = Menu.authorizedUser.GetFirstName() + " " + Menu.authorizedUser.GetLastName();
		bool isInMenu = true;
		while (isInMenu)
		{
			Console.Clear();
			// Show options for the customer
			Console.WriteLine("Welcome " + currentUser + "!" );
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
					EditReservation();
					continue;
				case "4":
					RemoveReservation();
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
