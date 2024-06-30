using System;
namespace CarBook.Dto.BannerDTOs
{
	public class CreateBannerDto
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoURL { get; set; }
    }
}

