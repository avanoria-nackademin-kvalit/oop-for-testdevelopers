@startuml
title Registrera en företagskund

actor Användare as User
boundary CustomerDialog as Dialog
control CustomerService as Service
entity Customer as Customer
database CustomerRepository as Repository

Dialog -> User : Visa "NEW CUSTOMER"
Dialog -> User : Visa "Follow the wizard to create a new customer."

loop Tills kunden har registrerats
    Dialog -> User : Be om företagsnamn
    User --> Dialog : Företagsnamn

    Dialog -> User : Be om organisationsnummer
    User --> Dialog : Organisationsnummer

    Dialog -> User : Be om e-postadress
    User --> Dialog : E-postadress

    Dialog -> Dialog : Normalisera uppgifterna
    Dialog -> Dialog : Validera obligatoriska uppgifter,\norganisationsnummer och e-postadress

    alt Inmatningen är ogiltig
        Dialog -> User : Visa vad som är fel i inmatningen

    else Inmatningen är giltig
        Dialog -> Service : register_customer(registration_dto)

        Service -> Service : Validera obligatoriska uppgifter\noch e-postadress
        Service -> Service : Kontrollera organisationsnumrets\nformat och kontrollsiffra

        alt Uppgifterna är ogiltiga
            Service --> Dialog : RegistrationResult(false, valideringsmeddelande)
            Dialog -> User : Visa valideringsmeddelandet

        else Uppgifterna är giltiga
            Service -> Repository : exists_by_organization_number(organization_number)
            Repository --> Service : Finns kunden?

            alt Kunden finns redan
                Service --> Dialog : RegistrationResult(false, "Kunden finns redan.")
                Dialog -> User : Visa "Kunden finns redan."

            else Kunden finns inte
                create Customer
                Service -> Customer : Skapa kund med registreringsuppgifterna

                Service -> Repository : add(customer)
                Repository -> Repository : Spara kunden i listan/databasen
                Repository --> Service : Kunden har sparats

                Service --> Dialog : RegistrationResult(true,\n"Kunden har registrerats.", customer)
                Dialog -> User : Visa "Kunden har registrerats."
                Dialog -> User : Visa kundens uppgifter
            end
        end
    end
end

@enduml