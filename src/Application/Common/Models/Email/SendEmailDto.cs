namespace Application.Common.Models.Email;

public class SendEmailDto
{
    public List<string> EmailAddressess { get; set; }
    public string Content { get; set; }
    public string Subject { get; set; }

    public SendEmailDto(List<string> emailAddressess, string content,string subject)
    {
        EmailAddressess = emailAddressess;

        Content = content;
        
        Subject = subject;
    }
    
    public SendEmailDto(string emailAddress, string content,string subject)
    {
        EmailAddressess = new List<string>(){ emailAddress };

        Content = content;
        
        Subject = subject;
    }
}