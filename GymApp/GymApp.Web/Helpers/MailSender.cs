using System.Net.Mail;
using System.Net;
using System.Drawing.Text;
using Microsoft.IdentityModel.Tokens;

namespace GymApp.Web.Helpers
{
	public static class MailSender
	{
		private const string SenderMail = "denemepiksel2@outlook.com";
		private const string SenderPassword = "mhmtemn00";


		public static void SendMail(string FullName,  List<string> mailAddresses, string Title,string Message) 

		{
			

			try
			{
				MailMessage mailMessage = new MailMessage();
				mailMessage.From = new MailAddress(SenderMail);
				for (int i = 0; i < mailAddresses.Count; i++)
				{
					mailMessage.To.Add(mailAddresses[i]);
				}
				mailMessage.Subject = "Hoş Geldiniz";
				mailMessage.Body = $"<h1>Merhaba{FullName}<h1>, \n Sitemize Hoş Geldin.";
				mailMessage.IsBodyHtml = true;

				SmtpClient smtpClient = new SmtpClient();
				smtpClient.Host = "smtp-mail.outlook.com";
				smtpClient.Port = 587;
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(SenderMail, SenderPassword);
				smtpClient.EnableSsl = true;
				smtpClient.Send(mailMessage);
				Console.WriteLine("Email Sent Successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}

		   
    }
}
