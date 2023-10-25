using System.Net;
using FluentResults;

namespace CashBusiness.Application.Common.Errors.Customer;

public class NotFoundCustomer: IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();
    
    public List<IError> Reasons { get; } = new List<IError>();


    public NotFoundCustomer(string message)
    {   
        Message = message;
        Metadata.Add("statusCode", HttpStatusCode.NotFound);

    }

}