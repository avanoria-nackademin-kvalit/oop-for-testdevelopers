from dataclasses import dataclass

from models.customer import Customer

@dataclass
class CreateCustomerResult:
    succeeded: bool
    error_message: str | None
    customer: Customer | None