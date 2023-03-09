using BLL.Services.Dto;

namespace MyMessenger.ViewModel;

public class ChatsAndSelected
{
    public IEnumerable<ChatDto> Chats { get; set; }
    public Tuple<string,ChatDto> Selected { get; set; }
}