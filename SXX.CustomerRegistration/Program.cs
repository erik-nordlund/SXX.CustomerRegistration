using SXX.CustomerRegistration.Repositories;
using SXX.CustomerRegistration.Services;

ICustomerRepository repository = new CustomerRepository();
ICustomerService customerService = new CustomerService(repository);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("===== SXX Kundregistrering =====");
    Console.WriteLine("1. Registrera privatperson");
    Console.WriteLine("2. Registrera företag");
    Console.WriteLine("3. Visa alla kunder");
    Console.WriteLine("0. Avsluta");
    Console.Write("Välj ett alternativ: ");

    string? choice = Console.ReadLine();

    if (choice == "0")
    {
        running = false;
        continue;
    }

    if (choice == "3")
    {
        var customers = repository.GetAllCustomers();

        if (customers.Count == 0)
        {
            Console.WriteLine("Inga kunder är registrerade.");
        }
        else
        {
            foreach (var customer in customers)
            {
                string type = customer.IsCompany
                    ? "Företag"
                    : "Privatperson";

                Console.WriteLine();
                Console.WriteLine($"Kund-ID: {customer.Id}");
                Console.WriteLine($"Kundtyp: {type}");
                Console.WriteLine($"Namn: {customer.CustomerName}");
                Console.WriteLine($"E-post: {customer.Email}");

                if (customer.IsCompany)
                {
                    Console.WriteLine(
                        $"Företag: {customer.CompanyName}");
                    Console.WriteLine(
                        $"Organisationsnummer: {customer.OrganizationNumber}");
                }
            }
        }

        continue;
    }

    if (choice != "1" && choice != "2")
    {
        Console.WriteLine("Fel: Du måste välja en giltig kundtyp.");
        continue;
    }

    bool isCompany = choice == "2";

    Console.WriteLine();
    Console.WriteLine(isCompany
        ? "--- Registrera företag ---"
        : "--- Registrera privatperson ---");

    Console.Write("Kundens namn: ");
    string customerName = Console.ReadLine() ?? "";

    Console.Write("E-postadress: ");
    string email = Console.ReadLine() ?? "";

    Console.Write("Telefonnummer: ");
    string phone = Console.ReadLine() ?? "";

    string? companyName = null;
    string? orgNumber = null;

    if (isCompany)
    {
        Console.Write("Företagsnamn: ");
        companyName = Console.ReadLine();

        Console.Write("Organisationsnummer: ");
        orgNumber = Console.ReadLine();
    }

    try
    {
        var customer = customerService.CreateCustomer(
            customerName,
            email,
            phone,
            isCompany,
            companyName,
            orgNumber
        );

        Console.WriteLine();
        Console.WriteLine("Kunden registrerades!");

        Console.WriteLine($"Kund-ID: {customer.Id}");

        Console.WriteLine(customer.IsCompany
            ? "Kundtyp: Företag"
            : "Kundtyp: Privatperson");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Fel: {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Fel: {ex.Message}");
    }
}

Console.WriteLine("Programmet avslutas.");