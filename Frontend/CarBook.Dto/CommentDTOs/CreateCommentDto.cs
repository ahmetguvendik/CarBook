using System;
namespace CarBook.Dto.CommentDTOs
{
	public class CreateCommentDto
	{
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }
        public string BlogId { get; set; }  
    }
}

