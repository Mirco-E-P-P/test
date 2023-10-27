using System.Net;
using FluentResults;

namespace CashBusiness.Application.Common.Errors;

public class CustomerNotFound: IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();
    public List<IError> Reasons { get; } = new List<IError>();


    public CustomerNotFound(string message = "Customer not found")
    {   
        Message = message;
        Metadata.Add("statusCode", HttpStatusCode.Conflict);

    }

}