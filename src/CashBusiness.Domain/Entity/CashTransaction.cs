namespace CashBusiness.Domain.Entity;

public class CashTransaction
{
    public int Index;
    public Guid Id { get; set; } = Guid.NewGuid();
   
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    
    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = default!;
    
    public string Voucher { get; set; } = String.Empty;
    public double Amount { get; set; } = 0.0;
    public string Observation { get; set; } = String.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}