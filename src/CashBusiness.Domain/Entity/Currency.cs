namespace  CashBusiness.Domain.Entity;


public class Currency{
    private Guid id = Guid.NewGuid();
    private string name { get; set; }
}