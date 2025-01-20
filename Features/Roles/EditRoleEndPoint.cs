using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class EditRoleEndpoint : Endpoint<EditRoleRequest>
{
    private readonly ApplicationDbContext _context;

    public EditRoleEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Patch("api/role/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EditRoleRequest req, CancellationToken ct)
    {
        var ctx = _context.Set<Role>();
        await ctx.Where(x => x.RoleId == int.Parse(req.Id))
            .ExecuteUpdateAsync(x => x.SetProperty(y => y.RoleName, req.Name));
        await _context.SaveChangesAsync(ct);

        await SendAsync("Berhasil");
    }
}
