using Carbook.Application.Features.CQRS.Commands.CategoryCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CategoryHandlers.Write;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
{
    private readonly IRepository<Category> _categoryRepository;

    public RemoveCategoryCommandHandler( IRepository<Category> categoryRepository)
    {
         _categoryRepository = categoryRepository;
    }
    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        await _categoryRepository.RemoveAsync(category);
        
    }
}