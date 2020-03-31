using System;

public class Actor
{
    private Guid id;
    private string firstName;
    private string lastName;

    // Constructor
	public Actor(string id, string firstName, string lastName)
	{
        this.id = new Guid(id.Replace("-", ""));
        this.firstName = firstName;
        this.lastName = lastName;
	}

    public string GetFirstName()
    {
        return this.firstName;
    }

    public string GetLastName()
    {
        return this.lastName;
    }
}
