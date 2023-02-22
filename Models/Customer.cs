using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesDb_Project.Models;
public class Customer
{
    //Id, first name, last name, country, postal code,
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Country { get; set; } = null!;

    public string? PostalCode { get; set; } = null!;

    public string? Phone { get; set; } = null!;

    public string? Email { get; set; } = null!;

}

