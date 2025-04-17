namespace CarBook.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; } 
    public string Email { get; set; }
    public List<RentACarProcess> RentACarProcesses { get; set; }
}