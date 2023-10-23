namespace CashBusiness.Contracts.Transaction.vo;

public class CashTransactionVo
{
    public Guid Id { get; set; } = Guid.Empty;

    public string ClientId { get; set; } = String.Empty;
    public string Voucher { get; set; } = String.Empty;
    public string OperationId { get; set; } = String.Empty;
    public double Amount { get; set; } = 0.0;
    public string Observation { get; set; } = String.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}