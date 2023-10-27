namespace CashBusiness.Contracts.Customer.Requests;

public class CreateCustomerRequest
{
    public string Name { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
}