from dataclasses import dataclass

@dataclass (frozen=True)
class SaveCustomerResponse:
    succeeded : bool
    error_message: str
