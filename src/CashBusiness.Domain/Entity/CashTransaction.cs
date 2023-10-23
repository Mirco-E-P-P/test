namespace CashBusiness.Domain.Entity;

public class CashTransaction
{
    public int Index;
    public Guid Id { get; set; } = Guid.NewGuid();
   
    public Guid CustomerId { get; set; }
    
    
    public string Voucher { get; set; } = String.Empty;
    public string OperationId { get; set; } = String.Empty;
    public double Amount { get; set; } = 0.0;
    public string Observation { get; set; } = String.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}