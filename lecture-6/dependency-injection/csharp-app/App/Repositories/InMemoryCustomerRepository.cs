using App.Models;

namespace App.Repositories;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = [];

    public IReadOnlyList<Customer> GetAll()
    {
        return _customers;
    }

    public void TryAdd(Customer customer)
    {
        _customers.Add(customer);
    }
}
