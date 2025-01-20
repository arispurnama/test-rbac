using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using MediatR;

namespace ApiCrud.Features.Permissions;
public class CreatePermissionCommand : Endpoint<CreatePermissionRequest>
{
    private readonly ApplicationDbContext _context;

    public CreatePermissionCommand(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/permision");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePermissionRequest req, CancellationToken ct)
    {
        var entt = new Permission
        {
            PermissionName = req.Name,
        };

        await _context.Set<Permission>().AddAsync(entt);
        await _context.SaveChangesAsync(ct);

        await SendAsync(entt);
    }
}

