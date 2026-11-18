from unittest.mock import Mock

import pytest

from models.customer import Customer
from models.create_customer_dto import CreateCustomerDto
from models.create_customer_result import CreateCustomerResult
from repositories.customer_repository import CustomerRepository
from services.customer_service import CustomerService

@pytest.fixture
def repository() -> Mock:
    return Mock(spec=CustomerRepository)

@pytest.fixture
def service(repository: Mock) -> CustomerService:
    return CustomerService(repository)

def test_get_customers__should_return_empty_list_of_customers(service: CustomerService, repository: Mock):
    # arrange
    repository.get_all.return_value = []

    # act
    result = service.get_customers()

    # assert
    assert result.succeeded is True
    assert result.error_message is None
    assert result.customers == []


def test_create_customer__should_normalize_and_save_customer_return_succeeded_with_customer(service: CustomerService, repository: Mock):
    # arrange
    dto = CreateCustomerDto(" Hans ", " Mattin-Lassei ", " Hans@domain.com ")
    returned_customer = Customer("Hans", "Mattin-Lassei", "hans@domain.com")
    repository.add.return_value = returned_customer

    # act
    result = service.create_customer(dto)

    # assert
    assert result.succeeded is True
    assert result.error_message is None

    customer = result.customer
    
    assert customer.first_name == "Hans"
    assert customer.last_name == "Mattin-Lassei"
    assert customer.email == "hans@domain.com"

    repository.add.assert_called_once_with(customer)


@pytest.mark.parametrize(
    "first_name, last_name, email, expected_error",
    [
        ("", "Mattin-Lassei", "hans@domain.com", "First name is required"),
        ("Hans", " ", "hans@domain.com", "Last name is required"),
        ("Hans", "Mattin-Lassei", "", "Email is required"),
    ]
)
def test_create_customer__should_validate_and_reject_missing_required_values(
    service: CustomerService,
    repository: Mock,
    first_name: str,
    last_name: str,
    email: str,
    expected_error: str 
): 
    # arrange
    dto = CreateCustomerDto(first_name, last_name, email)

    # act
    result = service.create_customer(dto)

    # assert
    assert result.succeeded is False
    assert result.error_message == expected_error

    repository.add.assert_not_called()