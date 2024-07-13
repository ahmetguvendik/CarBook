using System;
using CarBook.Application.Repositories;
using CarBook.Application.Repositories.GenericRepository;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CommentRepository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
	{
        private readonly CarBookDbContext _carBookDbContext;
        public CommentRepository(CarBookDbContext context) : base(context)
        {
            _carBookDbContext = context;
        }

        public async Task<List<Comment>> GetCommentsWithBlogId(string id)
        {
            var values = _carBookDbContext.Comments.Include(x => x.Blog).Where(x => x.BlogId == id).ToList();
            return values;
        }
    }
}

