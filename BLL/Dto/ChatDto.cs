namespace BLL.Services.Dto;

public class ChatDto
{
    public int Id { get; set; }
    public string ChatName { get; set; }
    public virtual ICollection<UserDto> Participants { get; set; }
    public virtual ICollection<MessegeDto> Messeges { get; set; }
}