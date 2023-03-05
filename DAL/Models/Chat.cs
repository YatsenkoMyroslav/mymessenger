using MyMessenger.Models;

namespace DAL.Models;

public class Chat
{
    public int Id { get; set; }
    public string ChatName { get; set; }
    public virtual ICollection<User> Participants { get; set; }
    public virtual ICollection<Messege> Messeges { get; set; }
}