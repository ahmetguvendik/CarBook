namespace CarBook.Domain.Entities;

public class AppRole : BaseEntity
{
    public string AppRoleName { get; set; }
    public List<AppUser> AppUsersType { get; set; }
}