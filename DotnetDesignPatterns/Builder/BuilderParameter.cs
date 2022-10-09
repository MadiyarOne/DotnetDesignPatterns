namespace DotnetDesignPatterns.Builder;

public class BuilderParameter
{
    static void Main(string[] args)
    {
        var ms = new EmailService();
        
        ms.Send(builder => builder.From("abc@.xyz.com").To("google@gmail.com"));
    }
}



class EmailService
{
    public class EmailBuilder
    {
        private readonly Email _email;

        internal EmailBuilder(Email email)
        {
            _email = email;
        }

        public EmailBuilder From(string from)
        {
            _email.From = from;
            return this;
        }
        
        public EmailBuilder To(string to)
        {
            _email.To = to;
            return this;
        }
        
        public EmailBuilder Body(string body)
        {
            _email.Body = body;
            return this;
        }
        
        public EmailBuilder Subject(string subject)
        {
            _email.Subject = subject;
            return this;
        }
    }
    public class Email
    {
        public string From, To, Subject, Body;
    }

    private void SendEmailInternal(Email email)
    {
        
    }
    
    public void Send(Action<EmailBuilder> builderAction)
    {
        var email = new Email();
        builderAction(new EmailBuilder(email));
        SendEmailInternal(email);
    }
}

