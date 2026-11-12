
using System.Net.Mail;

namespace SXX.CustomerRegistration.Models;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CustomerName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public bool IsCompany { get; set; }
    public string? CompanyName { get; set; }
    public string? OrganizationNumber { get; set; }

    public void ValidateCustomer()
    {
        if (string.IsNullOrWhiteSpace(CustomerName))
        {
            throw new ArgumentException(
                "Kundens namn måste anges.");
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            throw new ArgumentException(
                "E-postadress måste anges.");
        }

        if (!IsValidEmail(Email))
        {
            throw new ArgumentException(
                "E-postadressen har ett ogiltigt format.");
        }

        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            throw new ArgumentException(
                "Telefonnummer måste anges.");
        }

        if (IsCompany)
        {
            if (string.IsNullOrWhiteSpace(CompanyName))
            {
                throw new ArgumentException(
                    "Företagsnamn måste anges.");
            }

            if (string.IsNullOrWhiteSpace(OrganizationNumber))
            {
                throw new ArgumentException(
                    "Organisationsnummer måste anges.");
            }
        }
    }

    private static bool IsValidEmail(string email)
    {
        if (email.Any(char.IsWhiteSpace))
            return false;

        try
        {
            var address = new MailAddress(email);

            return address.Address == email
                && email.Contains('.');
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
