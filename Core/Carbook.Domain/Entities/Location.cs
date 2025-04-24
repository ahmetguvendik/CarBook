﻿using System;
namespace CarBook.Domain.Entities
{
	public class Location : BaseEntity
	{
		public string Name { get; set; }	
		public List<RentACar> RentACars { get; set; }
		public List<Reservation> PickUpReservation { get; set; }
		public List<Reservation> DropOffReservation { get; set; }	
	}	
}

