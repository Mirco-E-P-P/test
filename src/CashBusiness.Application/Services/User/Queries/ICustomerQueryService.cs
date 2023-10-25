﻿using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Queries;

public interface ICustomerQueryService
{
    public Task<Result<Customer>> FindCustomerByIdAsync(Guid id);
    public Task<Result<List<Customer>>> FindAllCustomersAsync();
}