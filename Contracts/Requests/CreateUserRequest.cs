namespace ApiCrud.Contracts.Requests;
public class CreateUserRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
public class EditUserRequest
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
