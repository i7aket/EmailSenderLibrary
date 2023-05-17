# EmailSenderLibrary

The EmailSenderLibrary is a simple and flexible .NET library for sending emails using MailKit.

## Configuration

### Add the following configuration to your application's `appsettings.json` file:

..json
{
  "EmailConfigurationGmail": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 465,
    "SmtpFromName": "no-reply@domain.ua",
    "SmtpUsername": "sendemail@domain.ua",
    "SmtpPassword": "password"
  }
}

### Dependency Injection
### In the Program.cs file, add the code to configure the service and perform dependency injection:

// Mail Configuration
builder.Services.AddSingleton<IEmailConfiguration>(builder.Configuration
    .GetSection("EmailConfigurationGmail").Get<EmailConfiguration>());

// For Identity System
builder.Services.AddTransient<IEmailSender, EmailSender>();


### Sending Emails
### You can now use the IEmailSender service to send emails. Here is an example of how to use it with an EmailDto:


var emailDto = new EmailDto
{
    To = "recipient@example.com",
    Subject = "Test Email",
    Body = "<h1>Hello, World!</h1>"
};
await _emailSender.SendEmailAsync(emailDto);


### And here is an example of sending an email directly without using EmailDto:


string recipientEmail = "recipient@example.com";
string subject = "Test Email";
string messageBody = "<h1>Hello, World!</h1>";
await _emailSender.SendEmailAsync(recipientEmail, subject, messageBody);


### Dependencies
MailKit
MimeKit
Microsoft.AspNetCore.Identity.UI