
from repositories.customer_repository import CustomerRepository
from models.get_customer_result import GetCustomerResult
from models.create_customer_dto import CreateCustomerDto
from models.create_customer_result import CreateCustomerResult
from models.customer import Customer

class CustomerService:
    def __init__(self, repository: CustomerRepository):
        self.__repository: CustomerRepository = repository

    def get_customers(self) -> GetCustomerResult:
        customers = self.__repository.get_all()

        return GetCustomerResult(True, None, customers)

    
    
    def create_customer(self, dto: CreateCustomerDto) -> CreateCustomerResult:

        # normalisera
        normalized_first_name = dto.first_name.strip()
        normalized_last_name = dto.last_name.strip()
        normalized_email = dto.email.strip().lower()

        # validera
        if not normalized_first_name:
           return CreateCustomerResult(False, "First name is required", None) 

        if not normalized_last_name:
           return CreateCustomerResult(False, "Last name is required", None) 

        if not normalized_email:
           return CreateCustomerResult(False, "Email is required", None) 
        
        # delegerar
        customer = Customer(normalized_first_name, normalized_last_name, normalized_email)
        created_customer = self.__repository.add(customer)

        # verifiera
        if not created_customer:
            return CreateCustomerResult(False, "Unable to save customer", None)

        # retunera lyckat resultat
        return CreateCustomerResult(True, None, created_customer)