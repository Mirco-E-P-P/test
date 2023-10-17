namespace CashBusiness.Domain.Entity;

public class Concept{
    public Guid id = Guid.NewGuid();
    public string name { get; set; } = null!;
}