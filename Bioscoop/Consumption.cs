using System;

public class Consumption
{
    public Guid id;
    public string name; // Name of the movie
    public string description; // Description of the movie
    public string size;
    public string[] allergies;
    public Consumption(string name, string description, string size, string[] allergies)
	{
        id = Guid.NewGuid();
        this.name = name;
        this.description = description;
        this.allergies = allergies;

    }
}
