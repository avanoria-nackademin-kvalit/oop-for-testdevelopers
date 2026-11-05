using App.Models;

namespace App.Repositories;

public class DatabaseCustomerRepository : ICustomerRepository
{
    public IReadOnlyList<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public void TryAdd(Customer customer)
    {
        throw new NotImplementedException();
    }
}
