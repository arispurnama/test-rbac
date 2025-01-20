using ApiCrud.Contracts.Requests;
using ApiCrud.Contracts.Responses;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class FindAllUserEndpoint : EndpointWithoutRequest<PaginationResponse<User>>
{
    private readonly ApplicationDbContext _context;

    public FindAllUserEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Get("api/user");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = _context.Users.AsNoTracking();
        var totalItems = await query.CountAsync(ct);
        var items = await query
            .ToListAsync(ct); 

        await SendAsync(new PaginationResponse<User> { Total = totalItems, Data = items }, cancellation: ct);
    }
}
