@startuml
title Registrera en företagskund

start

partition Dialog {
    :Visa "NEW CUSTOMER";
    :Visa "Follow the wizard to create a new customer.";
}

repeat
    partition Dialog {
        :Ange företagsnamn;
        :Ange organisationsnummer;
        :Ange e-postadress;

        :Normalisera uppgifterna;
        :Validera obligatoriska uppgifter,\norganisationsnummer och e-postadress;
    }

    if (Är inmatningen giltig?) then (ja)
        partition Service {
            :Ta emot registreringsuppgifterna;
            :Validera obligatoriska uppgifter\noch e-postadress;
            :Kontrollera organisationsnumrets\nformat och kontrollsiffra;
        }

        if (Är uppgifterna giltiga?) then (ja)
            partition Service {
                :Kontrollera om en kund med samma\nnormaliserade organisationsnummer finns;
            }

            if (Finns kunden redan?) then (ja)
                partition Service {
                    :Returnera misslyckat resultat med\n"Kunden finns redan.";
                }
            else (nej)
                partition Service {
                    :Skapa kunden;
                    :Spara kunden i listan/databasen;
                    :Returnera lyckat resultat med\nkundens uppgifter och\n"Kunden har registrerats.";
                }
            endif

        else (nej)
            partition Service {
                :Returnera misslyckat resultat\nmed valideringsmeddelande;
            }
        endif

        partition Dialog {
            :Skriv ut resultatets meddelande;
        }

    else (nej)
        partition Dialog {
            :Skriv ut vad som är fel i inmatningen;
        }
    endif

repeat while (Behöver användaren ange uppgifterna igen?) is (ja) not (nej)

partition Dialog {
    :Visa den registrerade kundens uppgifter;
}

stop
@enduml