namespace Carbook.Application.Features.CQRS.Results.ReservationResults;

public class GetReservationByIdQueryResult
{
    public string Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public int DriverLicanceYear { get; set; }
    public string? Message { get; set; }
    public string CarName { get; set; }
    public string PickUpLocationName { get; set; }
    public string DropOffLocationName { get; set; }
    public string Statues { get; set; }
}