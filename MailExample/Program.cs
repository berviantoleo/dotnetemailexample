using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

var smtpClient = new SmtpClient("smtp.ethereal.email")
{
    Port = 587,
    Credentials = new NetworkCredential("<email here>", "<pass here>"),
    EnableSsl = true,
};

var attachment = Attachment.CreateAttachmentFromString(JsonSerializer.Serialize(new
{
    Message = "Hello World!"
}), "helloworld.json", Encoding.UTF8, MediaTypeNames.Application.Json);

var message = new MailMessage("fromtest@test.com", "sendertest@test.com")
{
    Subject = "Test Email! Hello World!",
    Body = "<p>Test Email</p><b>Hello World!</b>",
    IsBodyHtml = true,
};

message.Attachments.Add(attachment);

try
{
    smtpClient.Send(message);
}
catch (SmtpException ex)
{
    Console.WriteLine(ex.ToString());
}
