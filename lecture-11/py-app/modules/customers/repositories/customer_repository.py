from modules.customers.models.customer import Customer
from modules.customers.models.create_customer_result import CreateCustomerResult


class CustomerRepository:
    def __init__(self):
        self.customers: list[Customer] = []

    def add(self, customer: Customer) -> CreateCustomerResult:
        self.customers.append(customer)
        return CreateCustomerResult(True, None)

    def get_by_email(self, email: str) -> Customer | None:
        return next(
            (customer for customer in self.customers if customer.email == email),
            None,
        )