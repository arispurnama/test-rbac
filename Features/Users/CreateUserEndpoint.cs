using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using MediatR;

namespace ApiCrud.Features.Permissions;
public class CreateUserEndpoint : Endpoint<CreateUserRequest>
{
    private readonly ApplicationDbContext _context;

    public CreateUserEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/user");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var entt = new User
        {
            UserName = req.UserName,
            Password = req.Password,
            Email = req.Email,
        };

        await _context.Set<User>().AddAsync(entt);
        await _context.SaveChangesAsync(ct);

        await SendAsync(entt);
    }
}

