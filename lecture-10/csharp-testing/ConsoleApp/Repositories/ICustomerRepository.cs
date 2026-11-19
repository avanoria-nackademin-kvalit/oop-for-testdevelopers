using ConsoleApp.Models;

namespace ConsoleApp.Repositories;

public interface ICustomerRepository
{
    Customer? Add(Customer customer);
    IReadOnlyList<Customer> GetAll();
}