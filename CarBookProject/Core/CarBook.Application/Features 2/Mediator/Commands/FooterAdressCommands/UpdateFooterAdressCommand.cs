using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAdressCommands
{
	public class UpdateFooterAdressCommand : IRequest
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
    }
}

