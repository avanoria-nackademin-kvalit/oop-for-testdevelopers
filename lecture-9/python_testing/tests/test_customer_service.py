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


def test_get_customers__should_return_empty_list_of_customers(
        service: CustomerService, 
        repository: Mock
):
    # arrange
    repository.get_all.return_value = []

    # act
    result = service.get_customers()

    # assert
    assert result.succeeded is True
    assert result.error_message is None
    assert result.customers == []

