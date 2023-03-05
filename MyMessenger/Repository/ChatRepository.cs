using MyMessenger.Data;
using MyMessenger.Models;

namespace MyMessenger.Repository;

public class ChatRepository:Repository<Chat>
{
    public ChatRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}