using Application.Auth.Model;
using MailKit.Net.Smtp;
using MimeKit;
using Shared.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Ultilities.Email
{
    public static class EmailUtil
    {
        private static readonly EmailConfiguration _emailConfig;

        public static async Task SendConfirmedEmailAsync(MessageVM message, AppUser user)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    string email = message.To[0].Address;
                    //var user = _userManager.FindByEmailAsync(email);
                    var emailMessage = CreateConfirmedEmailMessage(message);
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {
                    throw new AppException(ex.Message, ex);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        public static void SendEmail(MessageVM message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        public static Task SendEmailAsync(MessageVM message)
        {
            var mailMessage = CreateEmailMessage(message);
            return SendAsync(mailMessage);
        }

        private static MimeMessage CreateEmailMessage(MessageVM message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private static MimeMessage CreateConfirmedEmailMessage(MessageVM message)
        {
            // Read confirm email content
            string FilePath = Directory.GetCurrentDirectory() + "\\Resources\\EmailContents\\ConfirmedEmail.html";
            StreamReader str = new StreamReader(FilePath);
            string mailText = str.ReadToEnd();
            str.Close();
            // Replace username & email for specific ones
            mailText = mailText.Replace("[username]", message.To[0].Address.Split('@')[0]).Replace("[email]", message.To[0].Address);
            mailText = mailText.Replace("[linkconfirm]", message.Content);
            // setup addresss of sender and recipient, content of email.
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.Add(MailboxAddress.Parse(message.To[0].Address));
            emailMessage.Subject = message.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailText;

            emailMessage.Body = builder.ToMessageBody();
            return emailMessage;
        }

        private static MimeMessage CreateLinkForgotPasswordMessage(MessageVM message)
        {
            // Read confirm email content
            string FilePath = Directory.GetCurrentDirectory() + "\\Resources\\EmailContents\\ResetPassword.html";
            StreamReader str = new StreamReader(FilePath);
            string mailText = str.ReadToEnd();
            str.Close();
            // Replace username & email for specific ones
            //mailText = mailText.Replace("[username]", message.To[0].Address.Split('@')[0]).Replace("[email]", message.To[0].Address);
            mailText = mailText.Replace("[linkResetPassword]", message.Content);
            // setup addresss of sender and recipient, content of email.
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.Add(MailboxAddress.Parse(message.To[0].Address));
            emailMessage.Subject = message.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailText;

            emailMessage.Body = builder.ToMessageBody();
            return emailMessage;
        }

        private static void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.

                    throw new AppException(ex.Message, ex);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private static async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception, or both.
                    throw new AppException(ex.Message, ex);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        public static async Task SendLinkForgotPasswordAsync(MessageVM message, AppUser user)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    string email = message.To[0].Address;
                    //var user = _userManager.FindByEmailAsync(email);
                    var emailMessage = CreateLinkForgotPasswordMessage(message);
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {
                    throw new AppException(ex.Message, ex);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}