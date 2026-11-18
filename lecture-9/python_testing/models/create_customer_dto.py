from dataclasses import dataclass

@dataclass
class CreateCustomerDto:
    first_name: str
    last_name: str
    email: str