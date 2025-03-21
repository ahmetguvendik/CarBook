using System;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Repositories.GenericRepository
{
	public interface ICommentRepository : IRepository<Comment>
	{
		Task<List<Comment>> GetCommentsWithBlogId(string id);
		Task<List<Comment>> GetAllCommentsWithBlogTitle();
	}
}

