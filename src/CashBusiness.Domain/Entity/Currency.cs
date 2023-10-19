namespace  CashBusiness.Domain.Entity;


public class Currency{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = String.Empty;
}