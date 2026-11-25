from dataclasses import dataclass

from models.save_customer_response import SaveCustomerResponse

@dataclass
class CustomerService:

    def save_customer(self):
        # normalize data

        # validate data
            # return error message if not valid
            return SaveCustomerResponse(False, "Invalid data")

        # save data
            return SaveCustomerResponse(False, "duplicated data")

            return SaveCustomerResponse(False, "Unable to save data")

        # return valid data
        return SaveCustomerResponse(True, None)