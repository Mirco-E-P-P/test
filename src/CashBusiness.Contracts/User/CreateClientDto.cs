﻿namespace CashBusiness.Contracts.User;

public class CreateClientDto
{
    public string Name { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
}