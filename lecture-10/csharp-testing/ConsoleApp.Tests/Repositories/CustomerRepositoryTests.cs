using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Tests.Repositories;

public class CustomerRepositoryTests
{
    [Fact]
    public void GetAll__Should_ReturnEmptyList_WhenNoCustomersIsAdded()
    {
        // Arrange
        var repository = new CustomerRepository();

        // Act
        var customers = repository.GetAll();

        // Assert
        Assert.Empty(customers);
        
    }


    [Fact]
    public void Add__Should_ReturnListWithCustomer_WhenCustomerIsAdded()
    {
        // Arrange
        var repository = new CustomerRepository();
        var customer = new Customer 
        { 
            FirstName = "Hans", 
            LastName = "Mattin-Lassei", 
            Email = "hans@domain.com" 
        };

        // Act
        var createdCustomer = repository.Add(customer);

        // Assert
        Assert.Same(customer, createdCustomer);
        Assert.Same(customer, Assert.Single(repository.GetAll()));

    }

    [Fact]
    public void Add__Should_ThrowsArgumentNullExceptionWithExpectedMessage_WhenCustomerIsNull()
    {
        // Arrange
        var repository = new CustomerRepository();
        var expectedMessage = new ArgumentNullException("customer").Message;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => repository.Add(null!));

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }
}
