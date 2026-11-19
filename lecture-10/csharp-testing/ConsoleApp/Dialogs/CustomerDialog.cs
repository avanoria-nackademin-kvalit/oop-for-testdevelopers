using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Dialogs;

public class CustomerDialog(ICustomerService service)
{
    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("######## MAIN MENU ########");
            Console.WriteLine("1. \t NEW CUSTOMER");
            Console.WriteLine("2. \t VIEW CUSTOMERS");
            Console.WriteLine("0. \t EXIT");
            Console.WriteLine("---------------------------");

            Console.Write("Option: ");
            var option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    AddOption();
                    break;

                case "2":
                    ListOption();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    public void AddOption()
    {
        Console.Clear();
        Console.WriteLine("######## NEW CUSTOMER ########");

        Console.Write("Enter First Name: ");
        var firstName = Console.ReadLine() ?? "";

        Console.Write("Enter Last Name: ");
        var lastName = Console.ReadLine() ?? "";

        Console.Write("Enter Email Address: ");
        var email = Console.ReadLine() ?? "";

        var dto = new CreateCustomerDto(firstName, lastName, email);

        var result = service.CreateCustomer(dto);

        if (!result.Succeeded || result.Customer is null)
            Console.WriteLine(result.ErrorMessage);
        else
        {
            var customer = result.Customer;

            Console.WriteLine("");
            Console.WriteLine("Customer created successfully.");
            Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}>");
        }

        Console.ReadKey();
    }

    public void ListOption()
    {
        Console.Clear();
        Console.WriteLine("######## CUSTOMER LIST ########");

        var result = service.GetCustomers();

        if (!result.Succeeded || result.Customers is null)
            Console.WriteLine("Unable to load customers");
        else
        {
            var customers = result.Customers;

            if (customers.Count > 0)
                foreach (var customer in customers)
                    Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}>");
            else
                Console.WriteLine("No customers added");
        }

        Console.ReadKey();
    }
}
