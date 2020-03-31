using System;

public class MovieTimes
{
	public Guid id;
	public Movie movie;
	public Room room;
	public DateTime date;

	public MovieTimes(string id, Movie movie, Room room, DateTime date)
	{
	this.id = new Guid(id.Replace("-", ""));
	this.movie = movie;
	this.room = room;
	this.date = date;
	}
}

