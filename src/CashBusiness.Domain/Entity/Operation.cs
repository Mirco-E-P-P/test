namespace CashBusiness.Domain.Entity;
public class Operation {
    private Guid id = Guid.NewGuid();
    private string name { get; set; } = null!;

}