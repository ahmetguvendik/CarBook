using System;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using Carbook.Application.Repositories;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers.Write
{
	public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
	{
        private readonly IRepository<Domain.Entities.FooterAdress> _repository;

        public UpdateFooterAdressCommandHandler(IRepository<Domain.Entities.FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Adress = request.Adress;
            value.Description = request.Description;
            value.Email = request.Email;
            value.FacebookLink = request.FacebookLink;
            value.InstagramLink = request.InstagramLink;
            value.PhoneNumber = request.PhoneNumber;
            value.TwitterLink = request.TwitterLink;
            await _repository.UpdateAsync(value);
        }
    }
}

