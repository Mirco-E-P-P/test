using System.Net;
using FluentResults;

namespace CashBusiness.Application.Common.Errors;

public class CashTransactionNotFound: IError
{
    public string Message { get; } = String.Empty; 
    public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();
    public List<IError> Reasons { get; } = new List<IError>();

    public CashTransactionNotFound(string message = "Cash transaction not found ")
    {
        Message = message;
        Metadata.Add("statusCode",HttpStatusCode.NotFound);
    }

}