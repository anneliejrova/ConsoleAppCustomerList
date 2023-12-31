
using ConsoleAppCustomerList.Models;
using System.Text.Json;

namespace ConsoleAppCustomerList.Services
{
    public class CustomerService
    {
        private List<Customer> _customers = [];


        public void AddCustomerToList(Customer customer)
        {
            if (!_customers.Any(x => x.Email == customer.Email))
                _customers.Add(customer);

            var jsonString = JsonSerializer.Serialize(_customers);

            File.WriteAllText("C:\\ec\\ConsoleAppCustomerList\\ConsoleAppCustomerList\\CustomerFiles\\CustomerList.json", jsonString);
        }


        public Customer GetCustomerFromList(string email)
        {
            var customer = _customers.FirstOrDefault(x => x.Email == email);
            return customer ??= null!;
        }


        public bool RemoveCustomerFromList(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
            {
                return false;
            }

            var existingCustomer = _customers.FirstOrDefault(x => x.CompanyName == customer.CompanyName);
            if (existingCustomer == null)
            {
                return false;
            }

            _customers.Remove(existingCustomer);
            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            var jsonString = File.ReadAllText("C:\\ec\\ConsoleAppCustomerList\\ConsoleAppCustomerList\\CustomerFiles\\CustomerList.json");

            _customers = JsonSerializer.Deserialize<List<Customer>>(jsonString) ?? null!;

            return _customers;
        }
    
    }
}
