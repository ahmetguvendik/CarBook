﻿using System;
namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
	public class RemoveContactCommand
	{
        public string Id { get; set; }

        public RemoveContactCommand(string id)
        {
            Id = id;
        }
    }
}

