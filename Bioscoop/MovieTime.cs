﻿using System;

public class MovieTime
{
	public Guid id;
	public Movie movie;
	public Room room;
	public DateTime date;

	public MovieTime(Movie movie, Room room, DateTime date)
	{
    id = Guid.NewGuid();
	this.movie = movie;
	this.room = room;
	this.date = date;
	}

	public string GetMovieTimeDetails()
	{
		return $"Title: {this.movie.GetMovieTitle()}\nDuration: {this.movie.GetMovieDuration()} minutes\nDate: {this.date.ToString("dddd dd MMMM yyyy HH:mm")} \n{this.room.GetRoomName()}";
	}
	public DateTime GetDate()
	{
		return this.date;
	}
	public Room GetRoom()
	{
		return this.room;
	}
	public Movie GetMovie()
	{
		return this.movie;
	}
}

