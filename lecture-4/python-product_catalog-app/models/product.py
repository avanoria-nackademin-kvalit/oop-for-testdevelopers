from uuid import uuid4, UUID

class Product:
    def __init__(self):
        self.id: UUID = uuid4()
        self.name: str
        self.price: str