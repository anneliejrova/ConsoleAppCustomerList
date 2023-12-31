

namespace ConsoleAppCustomerList.Models;

public class Customer 
{
    Guid CustomerId { get; set; } = Guid.NewGuid();
    public string CompanyName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public ContactPerson Person { get; set; } = new();


}
    