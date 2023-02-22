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
        bool ICustomerRepository.AddNewCustomer(Customer customer) { 
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email)\n" +
                           "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }


            return true;
          

        }


        bool ICustomerRepository.DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomerRepository.GetAllCustomers() // Get all customers in the database
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
                            customer.Id = reader.GetInt32(0);
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


        Customer ICustomerRepository.GetCustomer(int id) // Get customer by id
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = " + id;
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
                            customer.Id = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                customer.PostalCode = reader.GetString(4);
                            if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                                customer.Phone = reader.GetString(5);
                            if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                                customer.Email = reader.GetString(6);
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
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE '" + firstName.Replace("%", @"\%").Replace("_", @"\_") + "%'";

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
                            customer.Id = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                customer.PostalCode = reader.GetString(4);
                            if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                                customer.Phone = reader.GetString(5);
                            if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                                customer.Email = reader.GetString(6);

                        }
                    }

                    return customer;

                }
            }
            catch (SqlException ex) { Console.WriteLine(ex); }

            return customer;
        }

        List<Customer> ICustomerRepository.SelectCustomerPage(int limit, int offset) // Get customers with limit and offset
        {

            // Get customers in the database by limit and offset

            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode FROM Customer " +
                        "ORDER BY Id " +
                        "OFFSET @Offset ROWS " +
                        "FETCH NEXT @Limit ROWS ONLY";



                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Limit", limit);
                        command.Parameters.AddWithValue("@Offset", offset);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.Id = reader.GetInt32(0);
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


        bool ICustomerRepository.UpdateCustomer(int ID, Customer customer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();

                    string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email\n" +
                               "WHERE CustomerId = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ID);
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public string GetCustomersByHighestSpent()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string sql = "SELECT Customer.FirstName, SUM(Invoice.Total) AS TotalSpent\r\nFROM Customer\r\nJOIN Invoice ON Customer.CustomerId = Invoice.CustomerId\r\nGROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName\r\nORDER BY TotalSpent DESC;\r\n";
            
                try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstname = reader.GetString(0);
                            decimal totalSpent = reader.GetDecimal(1);
                            stringBuilder.AppendLine(firstname + ": " + totalSpent);
                        }
                    }
                }
            }
            catch (SqlException ex) { Console.WriteLine(ex); }

            return stringBuilder.ToString();

        }

    

    public string GetCustomersByCountry()
        {
            StringBuilder stringBuilder= new StringBuilder();

            string sql = "SELECT Country, COUNT(*) as CustomerCount FROM Customer GROUP BY Country ORDER BY CustomerCount DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string country = reader.GetString(0);
                            int customerCount = reader.GetInt32(1);
                            stringBuilder.AppendLine(country + ": " + customerCount);
                        }
                    }
                }
            }
            catch (SqlException ex) { Console.WriteLine(ex); }

            return stringBuilder.ToString();

        }

    }

}
