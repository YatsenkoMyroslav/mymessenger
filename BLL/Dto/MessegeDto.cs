namespace BLL.Services.Dto;

public class MessegeDto
{
    public UserDto Sender { get; set; }
    public string Value { get; set; }
    public DateTime SentOn { get; set; }
}