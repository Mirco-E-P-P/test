using System.Net;
using FluentResults;

namespace CashBusiness.Application.Common.Errors.Transaction;

public class NotFoundCashTransaction: IError
{
    public string Message { get; } = String.Empty; 
    public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();
    public List<IError> Reasons { get; } = new List<IError>();

    public NotFoundCashTransaction(string message)
    {
        Message = message;
        Metadata.Add("statusCode",HttpStatusCode.NotFound);
    }

}