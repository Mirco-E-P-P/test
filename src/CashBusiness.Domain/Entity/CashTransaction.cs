namespace CashBusiness.Domain.Entity;

public class CashTransaction
{
    private Guid Id = Guid.NewGuid();
    private DateTime dateTime { get; set; } 
    private string ConceptId { get; set; } = null!;
    private string UserId { get; set; } = null!;
    private string voucher { get; set; } = null!;
    private string CurrencyId { get; set; } = null!;
    private string OperationId { get; set; } = null!;
    private double Amount { get; set; }
    private string Obeservation { get; set; } = null!;
}