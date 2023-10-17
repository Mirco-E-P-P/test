namespace CashBusiness.Domain.Entity;

public class User
{
    private Guid Id = Guid.NewGuid();
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Email { get; set; }
    private string Password { get; set; }
    private string phoneNumber { get; set; }
    private string address { get; set; }
}
