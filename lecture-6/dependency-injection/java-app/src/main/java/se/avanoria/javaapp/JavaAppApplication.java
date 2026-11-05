package se.avanoria.javaapp;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import se.avanoria.javaapp.models.Customer;
import se.avanoria.javaapp.services.CustomerService;
import se.avanoria.javaapp.services.DefaultCustomerService;

import java.util.List;

@SpringBootApplication
public class JavaAppApplication {

    public static void main(String[] args) {
        SpringApplication.run(JavaAppApplication.class, args);

        CustomerService customerService = new DefaultCustomerService();

        Customer customer = new Customer(
                "Avanoria AB",
                "556851-9994",
                "info@domain.com"
        );

        customerService.addCustomer(customer);

        List<Customer> customers = customerService.getAllCustomers();

        for (Customer c : customers){
            System.out.printf("%s <%s>", c.getCustomerName(), c.getEmailAddress());
        }
    }

}
