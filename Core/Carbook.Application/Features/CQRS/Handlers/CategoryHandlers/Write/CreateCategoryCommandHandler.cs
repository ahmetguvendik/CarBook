using Carbook.Application.Features.CQRS.Commands.CategoryCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CategoryHandlers.Write;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly IRepository<Category> _categoryRepository;

    public CreateCategoryCommandHandler( IRepository<Category> categoryRepository)
    {
         _categoryRepository = categoryRepository;
    }
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category();
        category.Id = Guid.NewGuid().ToString();
        category.Name = request.Name;
        await _categoryRepository.CreateAsync(category);
    }
}