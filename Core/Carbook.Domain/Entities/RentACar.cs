namespace CarBook.Domain.Entities;

public class RentACar : BaseEntity
{
    public string CarId { get; set; }
    public Car Car { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; }
    public bool Available { get; set; }     
}   