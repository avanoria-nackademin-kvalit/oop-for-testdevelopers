
from repositories.customer_repository import CustomerRepository
from models.get_customer_result import GetCustomerResult

class CustomerService:
    def __init__(self, repository: CustomerRepository):
        self.__repository: CustomerRepository = repository

    def get_customers(self) -> GetCustomerResult:
        customers = self.__repository.get_all()

        return GetCustomerResult(True, None, customers)