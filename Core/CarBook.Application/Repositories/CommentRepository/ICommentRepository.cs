using System;
using CarBook.Domain.Entities;

namespace CarBook.Application.Repositories.GenericRepository
{
	public interface ICommentRepository : IRepository<Comment>
	{
		Task<List<Comment>> GetCommentsWithBlogId(string id);
	}
}

