﻿using System;
namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands
{
	public class RemoveCategoryCommand
	{
        public string Id { get; set; }

        public RemoveCategoryCommand(string id)
        {
            Id = id;
        }
    }
}

