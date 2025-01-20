using ApiCrud.Contracts.Requests;
using ApiCrud.DataBase;
using ApiCrud.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Features.Permissions;
public class DeleteuserEndpoint : Endpoint<DeleteRequest>
{
    private readonly ApplicationDbContext _context;

    public DeleteuserEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Delete("api/user/{Id}");
    }
    public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
    {
        await _context.Set<User>().Where(x => x.UserId == int.Parse(req.Id)).ExecuteDeleteAsync(ct);
        await SendAsync("Berhasil", cancellation: ct);
    }
}