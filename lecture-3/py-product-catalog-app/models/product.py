from uuid import uuid4

class Product:
    def __init__(self):
        self.id = uuid4()
        self.name: str
        self.price: str