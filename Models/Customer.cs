namespace SuperheroesDb_Project.Models;
public class Customer
{
    // Customer class contains the different variables that are needed to complete the assignment. 
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Country { get; set; } = null!;

    public string? PostalCode { get; set; } = null!;

    public string? Phone { get; set; } = null!;

    public string? Email { get; set; } = null!;

}

