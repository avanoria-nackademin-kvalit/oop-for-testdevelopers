using App.Models;
using App.Services;

namespace App.Dialogs;

public class CustomerDialog(ICustomerService customerService)
{
    public void AddCustomerOption()
    {
        var customer = new Customer("Avanoria AB", "556851-9994", "info@domain.com");
        customerService.AddCustomer(customer);

        Console.WriteLine($"Customer with orgnr. '{customer.OrganizationNumber}' was created.");
        Console.ReadKey();
    }

    public void ShowCustomersOption()
    {
        var customers = customerService.GetAllCustomers();

        foreach (var customer in customers)
            Console.WriteLine($"{customer.CustomerName} <{customer.EmailAddress}>");

        Console.ReadKey();
    }
}
