namespace CarBook.Domain.Entities;

public class Reservation : BaseEntity
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public int DriverLicanceYear { get; set; }
    public string? Message { get; set; }
    public string CarId { get; set; }
    public Car Car { get; set; }
    public string PickUpLocationId { get; set; }
    public string DropOffLocationId { get; set; }
    public Location PickUpLocation { get; set; }
    public Location DrofOffLocation { get; set; }
    public string Statues { get; set; }
}