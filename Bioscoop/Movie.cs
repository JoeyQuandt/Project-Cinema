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
    public Movie(string id, string name, string description, int duration, Actor[] actors, DateTime releaseDate, int ageRestriction = 99)
    {
        this.movieId = new Guid(id.Replace("-", ""));
        this.name = name;
        this.description = description;
        this.duration = duration;
        //this.actors = actors;
        //this.releaseDate = releaseDate;
        //this.ageRestriction = ageRestriction;
    }

    /// <summary>
    /// Get all movie details in string format
    /// </summary>
    public string GetMovieDetails()
    {
        return "Title: "+this.name + "\n" + "Description: "+this.description + "\n" + "Duration: "+this.duration.ToString() + " minutes";
    }

    public string GetMovieTitle()
    {
        return this.name;
    }

    public string GetMovieDescription()
    {
        return this.description;
    }

    public int GetMovieDuration()
    {
        return this.duration;
    }

    public int GetAgeRestriction()
    {
        return this.ageRestriction;
    }

    public string GetMovieTitles()
    {
        return this.name;
    }

    public DateTime GetMoviereleaseDate()
    {
        return this.releaseDate;
    }

}
