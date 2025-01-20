using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class DeletePermissionEndpoint : Endpoint<DeleteRequest>
{
    private readonly ApplicationDbContext _context;

    public DeletePermissionEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/permission/{Id}");
    }
    public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
    {
        await _context.Set<Permission>().Where(x => x.PermissionId == int.Parse(req.Id)).ExecuteDeleteAsync(ct);
        await SendAsync("Berhasil", cancellation: ct);
    }
}