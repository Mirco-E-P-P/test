namespace CashBusiness.Domain.Entity;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Index { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
