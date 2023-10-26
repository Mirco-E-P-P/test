﻿using System.Net;
using FluentResults;

namespace CashBusiness.Application.Common.Errors;

public class OperationNotFound: IError
{
    public string Message { get;}
    public Dictionary<string, object> Metadata => new Dictionary<string, object>();
    public List<IError> Reasons { get; } = new List<IError>();

    
    public OperationNotFound(string message = "Operation not found")
    { 
        Metadata.Add("statusCode", HttpStatusCode.Conflict);
        Message = message;
        Console.WriteLine(Metadata["statusCode"]);
    }

}