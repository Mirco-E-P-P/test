namespace CashBusiness.Contracts.User.vo;

public class CustomerVo
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}