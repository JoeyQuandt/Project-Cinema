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
}
