using System;

public class User
{
    public Guid id;
    public string username;
    public string password; // Because who needs hashing
    public string firstName;
    public string lastName;
    public string description;
    public string role;

	public User(string username, string password, string firstName, string lastName, string role)
	{
        id = Guid.NewGuid();
        this.username = username;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
        this.description = "";
        this.role = role;
	}

    public bool VerifyLogin(string username, string password)
    {
        return this.username == username && this.password == password;
    }

    public string GetFirstName()
    {
        return this.firstName;
    }

    public string GetLastName()
    {
        return this.lastName;
    }

    public string GetRole()
    {
        return this.role;
    }

    public string GetUsername()
    {
        return this.username;
    }
}
