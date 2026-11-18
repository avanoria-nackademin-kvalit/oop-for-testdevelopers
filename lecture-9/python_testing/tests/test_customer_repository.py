from models.customer import Customer
from repositories.customer_repository import CustomerRepository

def test_get_all__should_return_empty_list_when_initialized():
    
    # arrange - förberedelser
    repository = CustomerRepository()

    # act - utförandet
    result = repository.get_all()

    # assert - utvärdering/kontroll
    assert result == []


def test_get_all_should_return_list_of_customers():

    # arrange
    repository = CustomerRepository()
    customer = Customer("Hans", "Mattin-Lassei", "hans@domain.com")
    repository.add(customer)

    # act
    result = repository.get_all()

    # assert
    assert result == [customer]

def test_add_should_add_customer_to_list_return_list_with_customer():

    # arrange
    repository = CustomerRepository()
    customer = Customer("Hans", "Mattin-Lassei", "hans@domain.com")

    # act
    repository.add(customer)

    # assert
    assert repository.get_all() == [customer]