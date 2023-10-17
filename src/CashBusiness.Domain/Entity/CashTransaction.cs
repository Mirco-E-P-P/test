namespace CashBusiness.Domain.Entity;

public class CashTransaction
{
    private Guid Id = Guid.NewGuid();
    private DateTime dateTime { get; set; }
    private string ConceptId { get; set; }
    private string UserId { get; set; }
    private string voucher { get; set; }
    private string CurrencyId { get; set; }
    private string OperationId { get; set; }
    private double Amount { get; set; }
    private string Obeservation { get; set; }
}