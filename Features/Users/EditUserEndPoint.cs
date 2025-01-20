using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class EditUserEndpoint : Endpoint<EditUserRequest>
{
    private readonly ApplicationDbContext _context;

    public EditUserEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Patch("api/user/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EditUserRequest req, CancellationToken ct)
    {
        var ctx = _context.Set<User>();
        await ctx.Where(x => x.UserId == int.Parse(req.UserId))
            .ExecuteUpdateAsync(x => x.SetProperty(y => y.UserName, req.UserName).SetProperty(y => y.Password, req.Password).SetProperty(y => y.Email, req.Email));
        await _context.SaveChangesAsync(ct);

        await SendAsync("Berhasil");
    }
}
