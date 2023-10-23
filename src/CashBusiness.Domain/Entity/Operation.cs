namespace CashBusiness.Domain.Entity;
public class Operation {
    public int Index { get; set; } = 0;
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = String.Empty;

}