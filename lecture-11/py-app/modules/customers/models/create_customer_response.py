from dataclasses import dataclass

from modules.customers.models.error_status import ErrorStatus
from modules.customers.models.customer import Customer

@dataclass(frozen=True)
class CreateCustomerResponse:
    succeeded: bool
    error_status: ErrorStatus | None
    customer: Customer