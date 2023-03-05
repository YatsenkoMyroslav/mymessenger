using DAL.Data;
using DAL.Models;
using MyMessenger.Data;
using MyMessenger.Models;

namespace DAL.Repository;

public class ChatRepository:Repository<Chat>
{
    public ChatRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}