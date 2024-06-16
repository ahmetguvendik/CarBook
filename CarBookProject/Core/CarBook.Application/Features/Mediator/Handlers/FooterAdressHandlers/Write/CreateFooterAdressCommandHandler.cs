using System;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers.Write
{
	public class CreateFooterAdressCommandHandler : IRequestHandler<CreateFooterAdressCommand>
    {
        private readonly IRepository<Domain.Entities.FooterAdress> _repository;
        public CreateFooterAdressCommandHandler(IRepository<Domain.Entities.FooterAdress> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var value = new FooterAdress();
            value.Id = Guid.NewGuid().ToString();
            value.PhoneNumber = request.PhoneNumber;
            value.InstagramLink = request.InstagramLink;
            value.TwitterLink = request.TwitterLink;
            value.FacebookLink = request.FacebookLink;
            value.Adress = request.Adress;
            value.Description = request.Description;
            value.Email = request.Email;
            await _repository.CreateAsync(value);
        }
    }
}

