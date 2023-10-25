using System.Net;
using FluentResults;

namespace CashBusiness.Application.Common.Errors.Transaction;

public class OperationNotFound: IError
{
    public string Message { get;} = String.Empty;
    public Dictionary<string, object> Metadata => new Dictionary<string, object>{{"statusCode", HttpStatusCode.Conflict}};
    public List<IError> Reasons { get; } = new List<IError>();

    
    public OperationNotFound(string message = "Operation not found")
    {
        Message = message;
    }

}