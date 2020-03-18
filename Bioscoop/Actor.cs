using System;

public class Actor
{
    private Guid actorId;
    private string firstName;
    private string lastName;

    // Constructor
	public Actor(string firstName, string lastName)
	{
        actorId = System.Guid.NewGuid();
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
