using App.Models;
using App.Services;

ICustomerService customerService = new DefaultCustomerService();

Customer customer = new Customer
(
    "Avanoria AB",
    "556851-9994",
    "info@domain.com"
);

customerService.AddCustomer(customer);

List<Customer> customers = customerService.GetAllCustomers();

foreach (Customer c in customers)
{
    Console.WriteLine($"{c.CustomerName} <{c.EmailAddress}>");
}

