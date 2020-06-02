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
    public string GetDetails()
    {
        string allergies = "";
        for (int j = 0; j < this.allergies.Length; j++)
        {
            allergies += j + 1 + ": " + this.allergies[j] + "\n";
        }
        return ($"Consumption: {this.name}\nDescription: {this.description}\nAllergy list:\n{allergies}");
    }
    public string GetName()
    {
        return ($"Consumption: {this.name}");
    }
}
