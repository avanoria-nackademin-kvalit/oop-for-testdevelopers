from dataclasses import dataclass

from models.customer import Customer

@dataclass
class GetCustomerResult:
    succeeded: bool
    error_message: str | None
    customers: list[Customer]