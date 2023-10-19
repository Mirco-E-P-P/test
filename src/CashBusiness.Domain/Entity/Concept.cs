namespace CashBusiness.Domain.Entity;

public class Concept
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = String.Empty;
}