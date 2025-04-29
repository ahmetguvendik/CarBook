namespace CarBook.Domain.Entities;

public class AppUser : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public AppRole AppRole { get; set; }
    public string AppRoleId { get; set; }
}