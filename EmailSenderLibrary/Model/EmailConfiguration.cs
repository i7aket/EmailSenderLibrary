
namespace EmailSenderLibrary
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int SmtpPort { get; set; }
        public string SmtpFromName { get; set; } = string.Empty;
        public string SmtpUsername { get; set; } = string.Empty;
        public string SmtpPassword { get; set; } = string.Empty;
    }
}
