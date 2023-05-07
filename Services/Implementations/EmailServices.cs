using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Interfaces;
using HtmlAgilityPack;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace ChurchManagementApi.Services.Implementations
{
    public class EmailServices : IEmailServices
    {
        private readonly SmtpClient _appSmtpClient;
        private readonly IConfiguration _configuration;

        public EmailServices(IConfiguration configuration)
        {
            _appSmtpClient = new(configuration.GetValue<string>("AppSmtpClient:Server"))
            {
                Credentials = new NetworkCredential()
                {
                    UserName = configuration.GetValue<string>("AppSmtpClient:Username"),
                    Password = configuration.GetValue<string>("AppSmtpClient:Password")
                },
                Port = 587,
                EnableSsl = true,
            };
            _configuration = configuration;
        }
        public void SendEmail(AutomatedEmail email, List<string> recipients)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration.GetValue<string>("AppSmtpClient:Username")),
                Subject = email.Subject,
                IsBodyHtml = true
            };

            // Load the HTML content into an HtmlDocument object
            var doc = new HtmlDocument();
            doc.LoadHtml(email.Content);

            // Select all image elements in the HTML content
            var imageElements = doc.DocumentNode.Descendants("img");

            foreach (var imageElement in imageElements)
            {
                // Get the base64-encoded image data from the src attribute
                var base64Image = imageElement.GetAttributeValue("src", null);
                if (base64Image != null && base64Image.StartsWith("data:image/"))
                {
                    // Convert the base64-encoded data to a byte array
                    var dataStartIndex = base64Image.IndexOf("base64,") + "base64,".Length;
                    var imageBytes = Convert.FromBase64String(base64Image.Substring(dataStartIndex));

                    // Create a new Attachment from the image bytes
                    var imageStream = new MemoryStream(imageBytes);
                    var imageAttachment = new Attachment(imageStream, "image.png");
                    imageAttachment.ContentDisposition.Inline = true;
                    imageAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    imageAttachment.ContentId = imageElement.GetAttributeValue("id", Guid.NewGuid().ToString());

                    // Add the Attachment to the MailMessage attachments collection
                    mailMessage.Attachments.Add(imageAttachment);

                    // Replace the image source in the HTML with the content ID of the Attachment
                    imageElement.Attributes["src"].Value = "cid:" + imageAttachment.ContentId;
                }
            }

            // Set the updated HTML content as the MailMessage body
            mailMessage.Body = doc.DocumentNode.OuterHtml;

            // Add the recipients to the Bcc field
            recipients.ForEach(recipient => mailMessage.Bcc.Add(recipient));

            // Send the email using the SMTP client
            _appSmtpClient.Send(mailMessage);
        }


    }
}
