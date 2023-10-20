﻿using FluentResults;

namespace CashBusiness.Application.Common.Errors.User;

public class ClientDuplicated: IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }= new Dictionary<string, object>();
    public List<IError> Reasons { get; }= new List<IError>();

    public ClientDuplicated(string message)
    {
        Message = message;
    }

}