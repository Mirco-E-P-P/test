namespace CashBusiness.Contracts.Transaction.dto;

public class RegisterCashTransactionDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string UserId { get; set; } = String.Empty;
    public string Voucher{ get; set; } = String.Empty;
    public string OperationId{ get; set; } = String.Empty;
    public double Amount { get; set; } = 0.0;
    public string Observation { get; set; } = String.Empty;
}