from dataclasses import dataclass

@dataclass(frozen=True)
class CreateCustomerRequest:
    first_name: str
    last_name: str
    email: str