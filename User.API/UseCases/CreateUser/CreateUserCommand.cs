using Contracts;
using MassTransit;
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
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateUserCommandHandler(ApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
    {
        this.dbContext = dbContext;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Users> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = Users.Create(request.FirstName, request.LastName,request.Email, request.Password);

        await dbContext.AddAsync(user);

        await dbContext.SaveChangesAsync(cancellationToken);


        await _publishEndpoint.Publish(
                new UserCreatedEvent
                {
                    EventId = Guid.NewGuid(),
                    UserId = user.Id,
                    CreatedOnUtc = DateTime.UtcNow,
                }, cancellationToken);

        return user;
    }
}