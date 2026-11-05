using App.Models;

namespace App.Services;

public interface ICustomerService
{
    void AddCustomer(Customer customer);
    List<Customer> GetAllCustomers();
}