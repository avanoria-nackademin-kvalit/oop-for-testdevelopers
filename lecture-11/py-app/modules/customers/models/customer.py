from dataclasses import dataclass
from uuid import UUID

@dataclass
class Customer:
    id : UUID
    first_name: str
    last_name: str
    email: str