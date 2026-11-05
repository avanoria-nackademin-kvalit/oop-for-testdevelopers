using App.Models;

namespace App.Repositories;

public interface ICustomerRepository
{
    void TryAdd(Customer customer);
    IReadOnlyList<Customer> GetAll();    
}
