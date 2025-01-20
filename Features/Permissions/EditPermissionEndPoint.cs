using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class EditPermissionEndPoint : Endpoint<EditPermissionRequest>
{
    private readonly ApplicationDbContext _context;

    public EditPermissionEndPoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Patch("api/permision/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EditPermissionRequest req, CancellationToken ct)
    {
        var ctx = _context.Set<Permission>();
        await ctx.Where(x => x.PermissionId == int.Parse(req.Id))
            .ExecuteUpdateAsync(x => x.SetProperty(y => y.PermissionName, req.Name));
        await _context.SaveChangesAsync(ct);

        await SendAsync("Berhasil");
    }
}
