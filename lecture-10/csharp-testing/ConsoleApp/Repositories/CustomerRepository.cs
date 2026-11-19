using ConsoleApp.Models;

namespace ConsoleApp.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = [];

    public Customer? Add(Customer customer)
    {
        _customers.Add(customer);
        return customer;
    }

    public IReadOnlyList<Customer> GetAll()
    {
        return _customers;
    }
}
