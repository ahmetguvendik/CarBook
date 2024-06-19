using System;
using CarBook.Application.Repositories.BlogRepository;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.BlogRepository
{
	public class BlogRepository : IBlogRepository
	{
        private readonly CarBookDbContext _carBookDbContext;
		public BlogRepository(CarBookDbContext carBookDbContext)
		{
            _carBookDbContext = carBookDbContext;
		}

        public async Task<List<Blog>> Get3BlogWithAuthor()
        {
            var blog = _carBookDbContext.Blogs.Include(x => x.Author).Take(3).ToList();
            return blog;
        }
    }
}

