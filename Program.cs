namespace SuperheroesDb_Project;

using SuperheroesDb_Project.Models;
using SuperheroesDb_Project.Repository;
using System;
using System.Data.SqlClient;

internal class Program
{
    static void Main(string[] args)
    {
        ICustomerRepository customerRepository = new CustomerRepository();


        InsertCustomer(customerRepository);
        
        

    }

    static void InsertCustomer(ICustomerRepository repository)
    {
        Console.WriteLine(repository.AddNewCustomer("Pavel", "Ibrahim", "Norway", "4879", "12345678", "Gjøk@gmail.com"));
    }

    static void SelectALL(ICustomerRepository repository, int limit, int offset)
    {
        PrintCustomers(repository.SelectCustomerPage(limit, offset));
    }

    static void SelectCustomer(ICustomerRepository repository, int ID)
    {
        PrintCustomer(repository.GetCustomer(ID));
    }

    static void SelectCustomer(ICustomerRepository repository, string name)
    {
        PrintCustomer(repository.GetCustomer(name));
    }

    static void PrintCustomers(IEnumerable<Customer> customers)
    {
        foreach (Customer customer in customers)
            PrintCustomer(customer);
    }



    static void PrintCustomer(Customer customer)

    {
        Console.WriteLine($"----{customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email}");
    }


}
