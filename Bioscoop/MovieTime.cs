using System;

public class MovieTime
{
	public Guid id;
	public Movie movie;
	public Room room;
	public DateTime date;

	public MovieTime(string id, Movie movie, Room room, DateTime date)
	{
	this.id = new Guid(id.Replace("-", ""));
	this.movie = movie;
	this.room = room;
	this.date = date;
	}

	public string GetMovieTimeDetails()
	{
		return $"{this.movie.GetMovieTitle()}: {this.date.ToString("F")}";
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

