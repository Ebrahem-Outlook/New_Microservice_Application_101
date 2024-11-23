using MediatR;
using User.API.Database;
using User.API.Models;

namespace User.API.UseCases.CreateUser;

public sealed record CreateUserCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password) : IRequest<Users>;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Users>
{
    private readonly ApplicationDbContext dbContext;

    public CreateUserCommandHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Users> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = Users.Create(request.FirstName, request.LastName,request.Email, request.Password);

        await dbContext.AddAsync(user);

        await dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }
}