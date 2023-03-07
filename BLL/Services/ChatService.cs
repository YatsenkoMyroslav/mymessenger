using BLL.Services.Dto;
using DAL.Models;
using DAL.Repository;
using MyMessenger.Models;

namespace BLL.Services;

public class ChatService:Service<Chat, ChatDto>
{
    public ChatService(IRepository<Chat> repository) : base(repository)
    {
    }

    public IEnumerable<ChatDto> GetUsersChat(User user)
    {
        var chats = repository.GetAll().Where(ch => ch.Participants.Contains(user));
        var chatsDto = chats.Select(c=>mapper.Map<Chat, ChatDto>(c));
        return chatsDto;
    }
}