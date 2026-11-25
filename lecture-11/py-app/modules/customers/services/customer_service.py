from dataclasses import dataclass
from uuid import uuid4

from modules.customers.repositories.customer_repository import CustomerRepository
from modules.customers.models.create_customer_request import CreateCustomerRequest
from modules.customers.models.create_customer_response import CreateCustomerResponse
from modules.customers.models.error_status import ErrorStatus
from modules.customers.models.customer import Customer

@dataclass
class CustomerService:
    customer_repository: CustomerRepository

    def create_customer(self, form_data: CreateCustomerRequest) -> CreateCustomerResponse:
        # normalize
        first_name = form_data.first_name.strip()
        last_name = form_data.last_name.strip()
        email = form_data.email.strip()

        # validate
        if not first_name or not last_name or not email:
            return CreateCustomerResponse(False, ErrorStatus.INVALID)

        # exists with email
        existing_customer = self.customer_repository.get_by_email(email)
        if existing_customer:
            return CreateCustomerResponse(False, ErrorStatus.DUPLICATE)

        # create
        id = uuid4()
        customer = Customer(id, first_name, last_name, email)

        # delegate
        result = self.customer_repository.add(customer)

        # return
        if result.succeeded:
            return CreateCustomerResponse(True, None, customer)

        return CreateCustomerResponse(False, ErrorStatus.ERROR)