namespace CashBusiness.Domain.Entity;
public class Operation {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = String.Empty;

}