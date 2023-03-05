namespace MyMessenger.Models;

public class Messege
{
    public int Id { get; set; }
    public User Sender { get; set; }
    public string Value { get; set; }
    public DateTime SentOn { get; set; }
}