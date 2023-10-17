namespace CashBusiness.Domain.Entity;

public class User
{
    private Guid Id = Guid.NewGuid();
    private string FirstName { get; set; } = null!;
    private string LastName { get; set; } = null!;
    private string Email { get; set; } = null!;
    private string Password { get; set; } = null!;
    private string phoneNumber { get; set; } = null!;
    private string address { get; set; } = null!;
}
