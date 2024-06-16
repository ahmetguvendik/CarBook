﻿using System;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers.Write
{
	public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
	{
        private readonly IRepository<Service> _repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}

