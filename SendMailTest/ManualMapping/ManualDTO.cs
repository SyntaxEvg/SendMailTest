
using DAL.SendMailTest.Enttity;
using SmtpServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailTest.ManualMapping
{
    public static class ManualDTO
    {
        /// <summary>
        /// Cоздает проекцию  модели в бд и обратно
        /// </summary>
        /// <param name="mailDTO"></param>
        /// <returns></returns>
        public static Mail AsDB (this MailDTO mailDTO) 
        {
            return new Mail
            {
                Create = DateTime.UtcNow,
                Subject = mailDTO.Subject,
                Body = mailDTO.Body,
                Recipients = mailDTO.Recipients.Where(x=> x != null).Select(sel => new Recipients()
                {
                    Recipient = sel,
                }).ToList(),
                Result = mailDTO.Result,
                FailedMessage = mailDTO.FailedMessage
            };

        }
        public static MailDTO AsDTO(this Mail mail) 
        {
            return new MailDTO
            {
                Subject = mail.Subject,
                Body = mail.Body,
                Recipients = mail.Recipients.Select(sel =>sel.Recipient).ToList(),
                Result = mail.Result,
                FailedMessage = mail.FailedMessage
            };
        }
    }
}
