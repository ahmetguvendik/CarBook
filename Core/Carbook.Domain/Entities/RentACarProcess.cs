using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace CarBook.Domain.Entities;

public class RentACarProcess : BaseEntity
{
    public Car Car { get; set; }
    public string CarId { get; set; }
    public int PickUpLocation { get; set; }
    public int DropOffLocation { get; set; }
    [Column(TypeName = "Date")]
    public DateTime PickUpDate { get; set; }
    [Column(TypeName = "Date")]
    public DateTime DropoffDate { get; set; }
    [DataType(DataType.Time)]
    public TimeSpan PickUpTime { get; set; }
    [DataType(DataType.Time)]
    public TimeSpan DropOffTime { get; set; }
    public Customer Customer { get; set; }
    public string CustomerId { get; set; }
    public string PickUppDescription { get; set; }
    public string DropOffDescription { get; set; }
    public decimal TotalPrice { get; set; }
}