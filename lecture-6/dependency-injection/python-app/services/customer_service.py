from typing import Protocol
from models.customer import Customer

class CustomerService(Protocol):
    
    def add_customer(self, customer: Customer) -> None:
        ...

    def get_all_customers(self) -> list[Customer]:
        ...