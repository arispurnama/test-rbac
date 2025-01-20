using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using MediatR;

namespace ApiCrud.Features.Permissions;
public class CreateRolesEndpoint : Endpoint<CreateRoleRequest>
{
    private readonly ApplicationDbContext _context;

    public CreateRolesEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/role");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRoleRequest req, CancellationToken ct)
    {
        var entt = new Role
        {
            RoleName = req.Name,
        };

        await _context.Set<Role>().AddAsync(entt);
        await _context.SaveChangesAsync(ct);

        await SendAsync(entt);
    }
}

