using Carbook.Application.Features.CQRS.Commands.CategoryCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CategoryHandlers.Write;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IRepository<Category> _categoryRepository;

    public UpdateCategoryCommandHandler( IRepository<Category> categoryRepository)
    { 
       _categoryRepository = categoryRepository;  
    }
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var value = await _categoryRepository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        await _categoryRepository.UpdateAsync(value);
    }
}