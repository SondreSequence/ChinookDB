namespace SuperheroesDb_Project;

using SuperheroesDb_Project.Models;
using SuperheroesDb_Project.Repository;
using System;
using System.Data.SqlClient;

internal class Program
{
    static void Main(string[] args)
    {
        //.... Test code here
    }

    // Can insert a customer (AddCustomer)
    static void InsertCustomer(ICustomerRepository repository, string firstName, string lastName, string country, string postalCode, string phone, string email)
    {
        Customer customer = new Customer();
        customer.FirstName = firstName;
        customer.LastName = lastName;
        customer.Country = country;
        customer.PostalCode = postalCode;
        customer.Phone = phone;
        customer.Email = email;

        Console.WriteLine(repository.AddNewCustomer(customer));
    }

    static void SelectALL(ICustomerRepository repository, int limit, int offset)
    {
        PrintCustomers(repository.SelectCustomerPage(limit, offset));
    }
    
    // Obtains a particular customer by ID
    static void SelectCustomer(ICustomerRepository repository, int ID)
    {
        PrintCustomer(repository.GetCustomer(ID));
    }

    // Obtains a particular customer by Name
    static void SelectCustomer(ICustomerRepository repository, string name)
    {
        PrintCustomer(repository.GetCustomer(name));
    }

    // OBtains Customers favorite genre
    static void SelectCustomerFavoriteGenre(ICustomerRepository repository, int ID)
    {
        Console.WriteLine(repository.GetCustomerFavoriteGenre(ID));
    }

    //We update all the customers old values. It does not say you must have the option to only update one value :P
    static void SelectUpdatedCustomer(ICustomerRepository repository, int ID)
    {
        Customer customer = new Customer();

        customer.FirstName = "Kokosnutt";
        customer.LastName = "KokosKokoko";
        customer.Country = "Finland";
        customer.PostalCode = "4321";
        customer.Phone = "21212121";
        customer.Email = "Gjok3@gmail.com";

        repository.UpdateCustomer(ID, customer);       
    }
    
    // Obtains countries in the database with respect to the customers...
    static void SelectCountries(ICustomerRepository repository)
    {
        Console.WriteLine(repository.GetCustomersByCountry());
    }

    // Prints out details about the customers.
    static void PrintCustomers(IEnumerable<Customer> customers)
    {
        foreach (Customer customer in customers)
            PrintCustomer(customer);
    }

    // Prints out details about a particular customer. 
    static void PrintCustomer(Customer customer)

    {
        Console.WriteLine($"----{customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email}");
    }


}
