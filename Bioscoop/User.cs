using System;

public class User
{
    private Guid id;
    private string username;
    private string password; // Because who needs hashing
    private string firstName;
    private string lastName;
    private string role;

	public User(string username, string password, string firstName, string lastName, string role)
	{
        id = Guid.NewGuid();
        this.username = username;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
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
}
