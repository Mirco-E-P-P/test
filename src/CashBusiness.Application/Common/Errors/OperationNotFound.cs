﻿using FluentResults;

namespace CashBusiness.Application.Common.Errors;

public class OperationNotFound: IError
{
    public string Message { get; } = String.Empty;
    public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();
    public List<IError> Reasons { get; } = new List<IError>();
    
    public OperationNotFound(string message = "Operation not found")
    {
        Message = message;
    }

}