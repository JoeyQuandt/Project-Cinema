using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public static class Customer
{ 
	// Function to ask the user to press enter to continuef
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
		// Get all reservations from JSON
		foreach (Reservation reservation in Data.LoadReservations())
		{
			if (reservation.GetReservationUser() == currentUser)
			{
				Console.WriteLine(reservation.GetReservationDetails() + "\n");
				reservationCount++;
			}
		}

		// Check and show how much reservations a customer has
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
		List<int> currentReservationNumbers = new List<int>();
		bool isInEditMode = true;
		while (isInEditMode)
		{
			Console.Clear();
			Console.WriteLine("<< Change a reservation >>\n");

			int totalReservationCount = 0;
			int userReservationCount = 0;
			// Get all reservations from JSON
			foreach (Reservation reservation in reservations)
			{
				totalReservationCount++;
				// Only show reservations of the current user
				if (reservation.GetReservationUser() == currentUser)
				{
					// Only show reservations whereby the movie has to start 
					if (reservation.movieRoom.GetDate() > DateTime.Now)
					{
						userReservationCount++;
						currentReservationNumbers.Add(totalReservationCount);
						Console.WriteLine("-- Reservation number " + totalReservationCount.ToString() + " -- \n" + reservation.GetReservationDetails() + "\n");
					}
				}
			}
			if (userReservationCount == 0)
			{
				Console.WriteLine("\nNo reservations found\nType 'x' to go back");
			}
			else
			{
				Console.WriteLine("\nEnter the number of the reservation to edit it.\nType 'x' to go back");
			}

			string userInput = Console.ReadLine();
			int x = 0;
			if (Int32.TryParse(userInput, out x))
			{
				// Check if user gives an valid input
				if (x > 0 && currentReservationNumbers.Contains(x))
				{
					Reservation reservation = reservations[x-1];
					DateTime currentDateTime = DateTime.Now;
					DateTime reservationDateTime = reservation.movieRoom.GetDate();

					// Check if it's not within 24 hours before start movie
					if (!(reservationDateTime <= currentDateTime.AddHours(24) && reservationDateTime >= currentDateTime.AddHours(-24)))
					{
						// Check if user really want to change the reservation
						Console.WriteLine("Are you sure? (y/n)");
						switch (Console.ReadLine().ToLower())
						{
							// Edit reservation
							case "y":
								// Remove old reservation
								reservations.RemoveAt(x - 1);
								var json2 = JsonConvert.SerializeObject(reservations, Formatting.Indented);
								File.WriteAllText(@"../../../data/reservationData.json", json2);
								// Make new reservation
								MakeReservation();
								// Reload reservationlist
								reservations = Data.LoadReservations();
								Console.WriteLine("You've succesfully changed the reservation!");
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
						// Error, the movie is within 24 hours
						Console.WriteLine("Sorry, you can't change your reservation anymore");
						PressEnter();
					}
				}
				else
				{
					// Error, give an valid reservation number
					if (userReservationCount != 0)
					{
						Console.WriteLine("Choose a number:");
						currentReservationNumbers.ForEach(item => Console.WriteLine(item));
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
		List<int> currentReservationNumbers = new List<int>();
		bool isInRemoveMode = true;
		while(isInRemoveMode)
		{
			Console.Clear();
			Console.WriteLine("<< Cancel a reservation >>\n");

			int totalReservationCount = 0;
			int userReservationCount = 0;
			// Get all reservations from JSON
			foreach(Reservation reservation in reservations)
			{
				totalReservationCount++;
				// Only show reservations of the current user
				if (reservation.GetReservationUser() == currentUser)
				{
					// Only show reservations whereby the movie has to start
					if (reservation.movieRoom.GetDate() > DateTime.Now)
					{
						userReservationCount++;
						currentReservationNumbers.Add(totalReservationCount);
						Console.WriteLine("-- Reservation number " + totalReservationCount.ToString() + " -- \n" + reservation.GetReservationDetails() + "\n");
					}
				}
			}
			if (userReservationCount == 0)
			{
				Console.WriteLine("\nNo reservations found\nType 'x' to go back");
			}
			else
			{
				Console.WriteLine("\nEnter the number of the reservation to cancel it.\nType 'x' to go back");
			}
			string userInput = Console.ReadLine();
			int x = 0;
			if (Int32.TryParse(userInput, out x))
			{
				// Check if user gives an valid input 
				if (x > 0 && currentReservationNumbers.Contains(x))
				{
					Reservation reservation = reservations[x - 1];
					DateTime currentDateTime = DateTime.Now;
					DateTime reservationDateTime = reservation.movieRoom.GetDate();

					// Check if it's not within 24 hours before start movie
					if (!(reservationDateTime <= currentDateTime.AddHours(24) && reservationDateTime >= currentDateTime.AddHours(-24)))
					{
						// Check if user really want to remove the reservation
						Console.WriteLine("Are you sure? y/n");
						switch (Console.ReadLine().ToLower())
						{
							// Remove reservation
							case "y":
								List<Reservation> reservationList = Data.LoadReservations();
								// Remove reservation in JSON
								reservationList.RemoveAt(x - 1);
								var json = JsonConvert.SerializeObject(reservationList, Formatting.Indented);
								File.WriteAllText(@"../../../data/reservationData.json", json);

								// Reload reservation list
								reservations = Data.LoadReservations();

								Console.WriteLine("You succesfully cancelled your reservation");
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
					// Error, the movie is within 24 hours
					else
					{
						Console.WriteLine("Sorry, you can't change your reservation anymore");
						PressEnter();
					}	
				}
				// Error, give an valid reservation number
				else 
				{
					if (userReservationCount != 0)
					{
						Console.WriteLine("Choose a number:");
						// Print reservation number options
						currentReservationNumbers.ForEach(item => Console.WriteLine(item));
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
			Console.WriteLine("1) Show movie times and availability");
			Console.WriteLine("2) Show list of current available movies");
			Console.WriteLine("3) Show ticket information");
			Console.WriteLine("4) View all your reservations");
			Console.WriteLine("5) Make a reservation");
			Console.WriteLine("6) Change a reservation");
			Console.WriteLine("7) Cancel a reservation");
			Console.WriteLine("8) Log out");

			switch (Console.ReadLine())
			{
				case "1":
					Menu.ShowMovieDetails();
					continue;
				case "2":
					Menu.ShowAvailableMovies();
					continue;
				case "3":
					Menu.ShowTicketDetails();
					continue;
				case "4":
					ShowReservations();
					continue;
				case "5":
					MakeReservation();
					continue;
				case "6":
					EditReservation();
					continue;
				case "7":
					RemoveReservation();
					continue;
				case "8":
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
