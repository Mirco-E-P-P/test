using FluentResults;

namespace CashBusiness.Application.Common.Errors;

public class OperationNotFound: IError
{
    public string Message { get; } = "Operation not found";
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}