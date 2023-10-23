namespace CashBusiness.Domain.Entity;

public class Client
{
    public int Index { get; set; } = 0;
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

}
