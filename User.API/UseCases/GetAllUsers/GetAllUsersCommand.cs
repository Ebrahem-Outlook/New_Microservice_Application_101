using MediatR;
using Microsoft.EntityFrameworkCore;
using User.API.Database;
using User.API.Models;

namespace User.API.UseCases.GetAllUsers;

public sealed record GetAllUsersCommand() : IRequest<List<Users>>;

internal sealed class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<Users>>
{
    private readonly ApplicationDbContext dbContext;

    public GetAllUsersCommandHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Users>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        var users = await dbContext.Users.ToListAsync();

        return users;
    }
}
