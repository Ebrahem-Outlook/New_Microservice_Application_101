using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Order.API.Database;
using Order.API.Models;

namespace Order.API.UseCase.GetAllOrders;

public sealed record GetAllOrderQuery() : IRequest<List<Orders>>;

internal sealed class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<Orders>>
{
    private readonly ApplicationDbContext dbContext;

    public GetAllOrderQueryHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Orders>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Orders.ToListAsync(cancellationToken);
    }
}