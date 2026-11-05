from services.default_customer_service import DefaultCustomerService
from services.customer_service import CustomerService
from models.customer import Customer

customer_service = DefaultCustomerService()

def add_customer(service: CustomerService) -> None:
    customer = Customer(
        "Avanoria AB",
        "556851-9994",
        "info@domain.com"
    )

    service.add_customer(customer)

def show_customers(service: CustomerService) -> None:
    for customer in service.get_all_customers():
        print(f"{customer.customer_name} <{customer.email_address}>")


add_customer(customer_service)
show_customers(customer_service)