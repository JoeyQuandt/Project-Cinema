using System;

public class Movie
{
    public Guid movieId;
    public string name; // Name of the movie
    public string description; // Description of the movie
    public int duration { get; set; }// In minutes
    public Actor[] actors; // A list of actors playing in the movie
    public DateTime releaseDate; // Releasedate
    public int ageRestriction; // Age restriction

    // Constructor
    public Movie(string id, string name, string description, int duration, Actor[] actors, DateTime releaseDate, int ageRestriction = 99)
    {
        this.movieId = new Guid(id.Replace("-", ""));
        this.name = name;
        this.description = description;
        this.duration = duration;
        //this.actors = actors;
        //this.releaseDate = releaseDate;
        this.ageRestriction = ageRestriction;
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

    public string GetAgeRestritction()
    {
        return this.ageRestriction;
    }

    public string GetMovieDescription()
    {
        return this.description;
    }

    public int GetMovieDuration()
    {
        return this.duration;
    }


    public DateTime GetMovieReleaseDate()
    {
        return this.releaseDate;
    }

}
