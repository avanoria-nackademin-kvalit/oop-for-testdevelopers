from dataclasses import dataclass

from modules.customers.models.error_status import ErrorStatus

@dataclass(frozen=True)
class CreateCustomerResult:
    succeeded: bool
    error_status: ErrorStatus | None