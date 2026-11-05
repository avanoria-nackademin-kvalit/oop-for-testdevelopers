from services.default_customer_service import DefaultCustomerService
from services.protocol_customer_service import ProtocolCustomerService
from models.customer import Customer

customer_service = DefaultCustomerService()

def add_customer(service: ProtocolCustomerService) -> None:
    customer = Customer(
        "Avanoria AB",
        "556851-9994",
        "info@domain.com"
    )

    service.add_customer(customer)

def show_customers(service: ProtocolCustomerService) -> None:
    customers = service.get_all_customers()

    for c in customers:
        print(f"{c.customer_name} <{c.email_address}>")


add_customer(customer_service)
show_customers(customer_service)