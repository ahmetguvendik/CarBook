namespace Carbook.Dto.FilterRentACar;

public class ResultFilterRentACarDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int PickUpLocationId { get; set; }
    public int DropOffLocationId { get; set; }
    public DateTime PickUpDate { get; set; }
    public DateTime DropOffDate { get; set; }
    public string PickUpTime { get; set; }
    public string DropOffTime { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerId { get; set; }
}