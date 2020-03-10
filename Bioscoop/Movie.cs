using System;

public class Movie
{
    private Guid movieId;
    private string name; // Name of the movie
    private string description; // Description of the movie
    private int duration { get; set; }// In minutes
    private Actor[] actors; // A list of actors playing in the movie
    private DateTime releaseDate; // Releasedate
    private int ageRestriction; // Age restriction

    // Constructor
    public Movie(string name, string description, int duration, Actor[] actors, DateTime releaseDate, int ageRestriction = 99)
    {
        movieId = System.Guid.NewGuid();
        this.name = name;
        this.description = description;
        this.duration = duration;
        this.actors = actors;
        this.releaseDate = releaseDate;
        this.ageRestriction = ageRestriction;
    }

    /// <summary>
    /// Get all movie details in string format
    /// </summary>
    public string GetMovieDetails()
    {
        return "Title:"+this.name + "\n" + "Description:"+this.description + "\n" + "Duration:"+this.duration.ToString() + " minutes";
    }

}
