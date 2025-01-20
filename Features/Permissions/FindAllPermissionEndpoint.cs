using ApiCrud.Contracts.Requests;
using ApiCrud.Contracts.Responses;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class FindAllPermissionEndpoint : Endpoint<PageRequest, ApiPages<Permission>>
{
    private readonly ApplicationDbContext _context;

    public FindAllPermissionEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/permission");
    }
    public override async Task<ApiPages<Permission>> ExecuteAsync(PageRequest req, CancellationToken ct)
    {
        var query = _context.Set<Permission>()
            .AsNoTracking();
        return await ApiPages<Permission>.CreateAsync(query, req);
    }
}
