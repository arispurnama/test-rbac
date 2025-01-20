using ApiCrud.Contracts.Requests;
using ApiCrud.Contracts.Responses;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class FindAllRoleEndpoint : EndpointWithoutRequest<PaginationResponse<Role>>
{
    private readonly ApplicationDbContext _context;

    public FindAllRoleEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Get("api/role");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = _context.Roles.AsNoTracking();
        var totalItems = await query.CountAsync(ct);
        var items = await query
            .ToListAsync(ct); 

        await SendAsync(new PaginationResponse<Role> { Total = totalItems, Data = items }, cancellation: ct);
    }
}
