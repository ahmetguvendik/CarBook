using System;
namespace CarBook.Domain.Entities
{
	public class Location : BaseEntity
	{
		public string Name { get; set; }	
		public List<RentACar> RentACars { get; set; }
	}	
}

