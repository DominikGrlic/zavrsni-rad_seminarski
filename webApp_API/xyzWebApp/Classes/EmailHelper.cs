using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using xyzWebApp.Helpers;

namespace xyzWebApp.Classes;

public static class EmailHelper
{
    public static async Task<bool> SendEmailPasswordReset(string userEmail, string username, string link)
    {
        try
        {
            var mimeMessage = new MimeMessage()
            {
                Sender = MailboxAddress.Parse("info@testapp.mom"),
                From = { new MailboxAddress(Encoding.UTF8, "TestApp", "info@testapp.mom") },
                Priority = MessagePriority.Urgent,
                Date = DateTimeOffset.UtcNow,
                Subject = "Password change!",
                To = { MailboxAddress.Parse(userEmail) }
            };

            var multipart = new Multipart("mixed");

            var htmlContent = await EmailFileHelper.GeneratePasswordResetHtml(username, link);
            
            var body = new TextPart(TextFormat.Html)
            {
                Text = htmlContent
            };
            
            multipart.Add(body);
            mimeMessage.Body = multipart;

             var client = new SmtpClient(); 

            await client.ConnectAsync("mail.privateemail.com", 465);
            await client.AuthenticateAsync("info@testapp.mom", "YlTS4I6IUrfV3Skzi5V1RAie8Q7DOyj5");

            var resp = await client.SendAsync(mimeMessage);
            Console.WriteLine(resp);
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public static async Task<bool> SendEmailConfirm(string userEmail, string username, string link)
    {
        try
        {
            var mimeMessage = new MimeMessage()
            {
                Sender = MailboxAddress.Parse("info@testapp.mom"),
                From = { new MailboxAddress(Encoding.UTF8, "TestApp", "info@testapp.mom") },
                Priority = MessagePriority.Urgent,
                Date = DateTimeOffset.UtcNow,
                Subject = "Confirm your email!",
                To = { MailboxAddress.Parse(userEmail) }
            };

            var multipart = new Multipart("mixed");

            var htmlContent = await EmailFileHelper.GenerateConfirmEmailHtml(username, link);
            
            var body = new TextPart(TextFormat.Html)
            {
                Text = htmlContent
            };
            
            multipart.Add(body);
            mimeMessage.Body = multipart;

            var client = new SmtpClient(); 

            await client.ConnectAsync("mail.privateemail.com", 465);
            await client.AuthenticateAsync("info@testapp.mom", "YlTS4I6IUrfV3Skzi5V1RAie8Q7DOyj5");

            var resp = await client.SendAsync(mimeMessage);
            Console.WriteLine(resp);
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public static async Task<bool> SendEmailConfirmSuccess(string userEmail)
    {
        try
        {
            var mimeMessage = new MimeMessage()
            {
                Sender = MailboxAddress.Parse("info@testapp.mom"),
                From = { new MailboxAddress(Encoding.UTF8, "TestApp", "info@testapp.mom") },
                Priority = MessagePriority.Urgent,
                Date = DateTimeOffset.UtcNow,
                Subject = "Your email is confirmed!",
                To = { MailboxAddress.Parse(userEmail) }
            };

            var multipart = new Multipart("mixed");

            var htmlContent = await EmailFileHelper.GenerateEmailSuccess();
            
            var body = new TextPart(TextFormat.Html)
            {
                Text = htmlContent
            };
            
            multipart.Add(body);
            mimeMessage.Body = multipart;

            var client = new SmtpClient(); 

            await client.ConnectAsync("mail.privateemail.com", 465);
            await client.AuthenticateAsync("info@testapp.mom", "YlTS4I6IUrfV3Skzi5V1RAie8Q7DOyj5");

            var resp = await client.SendAsync(mimeMessage);
            Console.WriteLine(resp);
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}