using System;
using CarBook.Application.Repositories;
using CarBook.Application.Repositories.GenericRepository;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Carbook.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CommentRepository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
	{
        private readonly CarBookDbContext _carBookDbContext;
        private ICommentRepository _commentRepositoryImplementation;

        public CommentRepository(CarBookDbContext context) : base(context)
        {
            _carBookDbContext = context;
        }

        public async Task<List<Comment>> GetCommentsWithBlogId(string id)
        {
            var values = _carBookDbContext.Comments.Include(x => x.Blog).Where(x => x.BlogId == id).ToList();
            return values;
        }

        public async Task<List<Comment>> GetAllCommentsWithBlogTitle()
        {
            var values = _carBookDbContext.Comments.Include(x => x.Blog).ToList();
           return values;
        }
    }
}

