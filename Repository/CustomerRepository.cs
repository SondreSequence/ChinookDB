using Microsoft.Data.SqlClient;
using SuperheroesDb_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesDb_Project.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        bool ICustomerRepository.AddNewCustomer(int id)
        {
            throw new NotImplementedException();
        }

        bool ICustomerRepository.DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomerRepository.GetAllCustomers()
        {
            List<Customer> CustomerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";

            try
            { //Connect
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.CustomerId = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                customer.PostalCode = reader.GetString(4);
                            if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                                customer.Phone = reader.GetString(5);
                            customer.Email = reader.GetString(6);
                            CustomerList.Add(customer);
                        }
                    }

                    return CustomerList;

                }
            }
            catch (SqlException ex) { Console.WriteLine(ex); }

            return CustomerList;
        }


        Customer ICustomerRepository.GetCustomer(int id)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode FROM Customer WHERE CustomerId = " + id;
            Customer customer = new Customer();

            try
            { //Connect
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.CustomerId = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                customer.PostalCode = reader.GetString(4);

                        }
                    }

                    return customer;

                }
            }
            catch (SqlException ex) { Console.WriteLine(ex); }

            return customer;
        }

        Customer ICustomerRepository.GetCustomer(string firstName) // Get customer by name
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode FROM Customer WHERE FirstName LIKE '" + firstName.Replace("%", @"\%").Replace("_", @"\_") + "%'";

            Customer customer = new Customer();

            try
            { //Connect
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.CustomerId = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                customer.Country = reader.GetString(3);
                            if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                customer.PostalCode = reader.GetString(4);

                        }
                    }

                    return customer;

                }
            }
            catch (SqlException ex) { Console.WriteLine(ex); }

            return customer;
        }

        List<Customer> ICustomerRepository.SelectCustomerPage(int limit, int offset)
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode FROM Customer " +
                        "ORDER BY CustomerId " +
                        "LIMIT @Limit " +
                        "OFFSET @Offset ROWS";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Limit", limit);
                        command.Parameters.AddWithValue("@Offset", offset);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                    customer.PostalCode = reader.GetString(4);

                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return customers;
        }


        bool ICustomerRepository.UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string name)
        {
            throw new NotImplementedException();
        }
    }
}
