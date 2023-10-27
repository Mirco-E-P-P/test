namespace CashBusiness.Contracts.CashTransaction.Requests;

public class UpdateCashTransactionRequest
{
     public Guid Id { get; set; } 
     public Guid CustomerId { get; set; }
     public Guid OperationId { get; set; }
     public string Voucher { get; set; } = String.Empty;
     public double Amount { get; set; } = 0.0;
     public string Observation { get; set; } = String.Empty;
}