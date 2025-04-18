﻿using System;
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

        public async Task<List<Blog>> GetAllBlogWithAuthor()
        {
            var blog = _carBookDbContext.Blogs.Include(x => x.Author).ToList();
            return blog;
        }

        public async Task<List<Blog>> GetAllBlogWithAuthorandCategory()
        {
            var blogs = await _carBookDbContext.Blogs
                .Include(x => x.Author)
                .Include(x => x.Category) 
                .ToListAsync();
            return blogs;
        }

        public async Task<List<Blog>> GetBlogWithAuthorByBlogId(string id)
        {
            var blog = _carBookDbContext.Blogs.Include(x => x.Author).Where(y => y.Id == id).ToList();
            return blog;
        }

        public async Task<List<Blog>> GetBlogWithCommentByBlogId(string id)
        {
            var blog = _carBookDbContext.Blogs.Include(x => x.Comments).Where(y => y.Id == id).ToList();
            return blog;
        }
    }
}

