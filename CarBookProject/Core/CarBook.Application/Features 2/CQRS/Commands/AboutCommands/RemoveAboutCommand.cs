﻿using System;
namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
	public class RemoveAboutCommand
	{
        public string id { get; set; }

        public RemoveAboutCommand(string Id)
        {
            id = Id;
        }
    }
}

