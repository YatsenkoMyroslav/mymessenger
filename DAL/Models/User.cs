using Microsoft.AspNetCore.Identity;

namespace MyMessenger.Models;

public class User: IdentityUser
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public virtual ICollection<Chat> Chats { get; set; }
}