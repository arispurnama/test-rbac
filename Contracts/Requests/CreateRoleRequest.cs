namespace ApiCrud.Contracts.Requests;
public class CreateRoleRequest
{
    public string Name { get; set; }
}
public class EditRoleRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
}
