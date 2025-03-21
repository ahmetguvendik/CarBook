using System;
using CarBook.Domain.Entities;
using System.Threading.Tasks;

namespace CarBook.Application.Repositories.BlogRepository
{
	public interface IBlogRepository
	{
        Task<List<Blog>> Get3BlogWithAuthor();
        Task<List<Blog>> GetAllBlogWithAuthor();
        Task<List<Blog>> GetAllBlogWithAuthorandCategory();
        
        Task<List<Blog>> GetBlogWithAuthorByBlogId(string id);
        Task<List<Blog>> GetBlogWithCommentByBlogId(string id);
    }
}

