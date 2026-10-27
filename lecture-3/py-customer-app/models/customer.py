from uuid import uuid4

class Customer:
    def __init__(self, first_name: str, last_name: str, email: str):
        self.id = uuid4()      
        self.first_name = first_name
        self.last_name = last_name
        self.email = email