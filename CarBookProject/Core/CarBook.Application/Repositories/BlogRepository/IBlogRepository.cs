﻿using System;
using CarBook.Domain.Entities;
using System.Threading.Tasks;

namespace CarBook.Application.Repositories.BlogRepository
{
	public interface IBlogRepository
	{
        Task<List<Blog>> Get3BlogWithAuthor();
    }
}
