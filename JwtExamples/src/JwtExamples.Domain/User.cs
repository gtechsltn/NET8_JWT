namespace JwtExamples.Domain;

public sealed class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public User(
        Guid id,
        string email,
        string password,
        string firstName,
        string lastName,
        DateTime createdAt)
    {
        Id = id;
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = createdAt;
    }
}