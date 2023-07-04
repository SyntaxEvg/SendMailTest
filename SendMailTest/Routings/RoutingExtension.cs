using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmtpServer.Models;
using System.Net.Mail;
using System.Net;
using DAL.VideoGamesTest.Contexts;
using Microsoft.AspNetCore.Mvc;
using SendMailTest.ManualMapping;
using DAL.SendMailTest.Enttity;

namespace SendMailTest.Routings
{
    public static class RoutingExtension
    {
        /// <summary>
        /// Обработчик для маршрутов
        /// </summary>
        /// <param name="app"></param>
        public static void Routing(this WebApplication? app)
        {
            // Обработчик для маршрута "/api/mails"
            app.MapGet("/api/mails", async ([FromServices] MailContext dbcontext) =>
            {
                IQueryable<Mail> query = dbcontext.Mail;
                var mail = await query.Select(x => x.AsDTO()).AsNoTracking().AsQueryable().ToListAsync();
                return Results.Ok(mail);
            });
            app.MapPost("/api/mails", async ([FromServices] MailContext dbcontext, HttpContext context ,MailDTO MailDTO ) =>
            {
                var smtpSettings = context.RequestServices.GetRequiredService<IOptions<SmtpSettings>>().Value;

               
                var smtpClient = new SmtpClient(smtpSettings.Server, smtpSettings.Port);
                smtpClient.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);

                var message = new MailMessage();
                var mail = MailDTO.AsDB();

                try
                {
                    message.From = new MailAddress(smtpSettings.Username); 
                    message.Subject = MailDTO.Subject;
                    message.Body = MailDTO.Body;
                    foreach (var recipient in MailDTO.Recipients)
                    {
                        message.To.Add(recipient);
                    }
                 
                    smtpClient.Send(message);

                    mail.Result = "OK";
                }
                catch (Exception ex)
                {
                    mail.Result = "Failed";
                    mail.FailedMessage = ex.Message;
                }

                
                dbcontext.Mail.Add(mail);
                await dbcontext.SaveChangesAsync();

                return Results.Ok(mail);
            });




            
        }
    }
}
