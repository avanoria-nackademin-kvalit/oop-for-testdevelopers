namespace App.Models;

public class Customer(string customerName, string organizationNumber, string emailAddress)
{
    public string CustomerName { get; set; } = customerName;
    public string OrganizationNumber { get; set; } = organizationNumber;
    public string EmailAddress { get; set; } = emailAddress;
}
