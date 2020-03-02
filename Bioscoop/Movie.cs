using System;

public class Movie
{
    private string name; // Name of the movie
    private string description; // Description of the movie
    private int duration; // In minutes
    private Actor[] actors; // A list of actors playing in the movie
    private DateTime releaseDate; // Releasedate

    // Constructor
    public Movie(string name, string description, int duration, Actor[] actors, DateTime releaseDate)
    {
        this.name = name;
        this.description = description;
        this.duration = duration;
        this.actors = actors;
        this.releaseDate = releaseDate;
    }

    public string getMovieDetails()
    {
        return this.name + "\n" + this.description + "\n" + this.duration.ToString() + " minutes";
    }

}
