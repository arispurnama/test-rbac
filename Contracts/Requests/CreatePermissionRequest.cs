namespace ApiCrud.Contracts.Requests;

public class CreatePermissionRequest
{
    public string Name { get; set; }
}
public class EditPermissionRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public record DeleteRequest(string Id);

