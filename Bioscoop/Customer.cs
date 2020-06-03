﻿using System;
using System.Collections.Generic;

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
		ColorChanger.TextColor(ConsoleColor.Red);
		Console.Write("Error, only use the given options...\n");
		ColorChanger.TextColor(ConsoleColor.White);
	}

	// Function to show reservations
	private static void ShowReservations()
	{
		string currentUser = Menu.authorizedUser.GetFirstName() + " " + Menu.authorizedUser.GetLastName();
		int reservationCount = 0;
		Console.Clear();
		ColorChanger.BackgroundColor(ConsoleColor.White);
		ColorChanger.TextColor(ConsoleColor.Black);
		Console.WriteLine("=====Your reservations=====\n");
		ColorChanger.BackgroundColor(ConsoleColor.Black);
		ColorChanger.TextColor(ConsoleColor.White);
		// Get all reservations from JSON
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
			ColorChanger.TextColor(ConsoleColor.Red);
			Console.WriteLine("No reservations found\n");
			ColorChanger.TextColor(ConsoleColor.White);
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
			ColorChanger.BackgroundColor(ConsoleColor.White);
			ColorChanger.TextColor(ConsoleColor.Black);
			Console.WriteLine("=====Change a reservation=====\n");
			ColorChanger.BackgroundColor(ConsoleColor.Black);
			ColorChanger.TextColor(ConsoleColor.White);

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
				ColorChanger.TextColor(ConsoleColor.Red);
				Console.WriteLine("\nNo reservations found");
				ColorChanger.TextColor(ConsoleColor.White);
				Console.WriteLine("Type 'x' to go back");
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
								ColorChanger.TextColor(ConsoleColor.Green);
								Console.WriteLine("You've succesfully changed the reservation!");
								ColorChanger.TextColor(ConsoleColor.White);
								PressEnter();
								continue;
							// Don't edit reservation
							case "n":
								ColorChanger.TextColor(ConsoleColor.Red);
								Console.WriteLine("You didn't changed the reservation.");
								ColorChanger.TextColor(ConsoleColor.White);
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
						ColorChanger.TextColor(ConsoleColor.Red);
						Console.WriteLine("Sorry, you can't change your reservation anymore");
						ColorChanger.TextColor(ConsoleColor.White);
						PressEnter();
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
				if (userInput.ToLower() != "x")
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
			ColorChanger.BackgroundColor(ConsoleColor.White);
			ColorChanger.TextColor(ConsoleColor.Black);
			Console.WriteLine("=====Cancel a reservation=====\n");
			ColorChanger.BackgroundColor(ConsoleColor.Black);
			ColorChanger.TextColor(ConsoleColor.White);

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
				ColorChanger.TextColor(ConsoleColor.Red);
				Console.WriteLine("\nNo reservations found");
				ColorChanger.TextColor(ConsoleColor.White);
				Console.WriteLine("Type 'x' to go back");
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

								ColorChanger.TextColor(ConsoleColor.Green);
								Console.WriteLine("You succesfully cancelled your reservation");
								ColorChanger.TextColor(ConsoleColor.White);
								PressEnter();
								continue;
							// Don't remove reservation
							case "n":
								ColorChanger.TextColor(ConsoleColor.Red);
								Console.WriteLine("You did not cancel the reservation");
								ColorChanger.TextColor(ConsoleColor.White);
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
						ColorChanger.TextColor(ConsoleColor.Red);
						Console.WriteLine("Sorry, you can't change your reservation anymore");
						ColorChanger.TextColor(ConsoleColor.White);
						PressEnter();
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
				if (userInput.ToLower() != "x")
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
			ColorChanger.BackgroundColor(ConsoleColor.White);
			ColorChanger.TextColor(ConsoleColor.Black);
			Console.WriteLine("=====Welcome " + currentUser + "!=====" );
			ColorChanger.BackgroundColor(ConsoleColor.Black);
			ColorChanger.TextColor(ConsoleColor.White);
			Console.WriteLine("1) Show movie times and availability");
			Console.WriteLine("2) Show list of current available movies");
			Console.WriteLine("3) Show ticket information");
			Console.WriteLine("4) Search for a movie");
			Console.WriteLine("5) View all your reservations");
			Console.WriteLine("6) Make a reservation");
			Console.WriteLine("7) Change a reservation");
			Console.WriteLine("8) Cancel a reservation");
			Console.WriteLine("9) Log out");

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
					Menu.SearchMovies();
					continue;
				case "5":
					ShowReservations();
					continue;
				case "6":
					MakeReservation();
					continue;
				case "7":
					EditReservation();
					continue;
				case "8":
					RemoveReservation();
					continue;
				case "9":
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
