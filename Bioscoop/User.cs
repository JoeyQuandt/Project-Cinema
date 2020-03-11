using System;

public class User
{
    private Guid userId;
    private string username;
    private string password; // Because who needs hashing
    private string firstName;
    private string lastName;

	public User(string id, string username, string password, string firstName, string lastName)
	{
        this.userId = new Guid(id.Replace("-", ""));
        this.username = username;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
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
}
