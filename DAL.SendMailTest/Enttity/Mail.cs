using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.SendMailTest.Enttity
{
    /// <summary>
    /// Необходимый минимум для письма 
    /// </summary>
    [Table(nameof(Mail), Schema = "Logger")]
    public class Mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// строка, представляющая заголовок письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        ///  строка, содержащая текст письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// список строк, содержащий адреса получателей письма
        /// </summary>
        public virtual  List<Recipients> Recipients { get; set; }
        /// <summary>
        /// строка, указывающая результат отправки письма. Может принимать значения "OK" или "Failed"
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// строка, содержащая сообщение об ошибке, если отправка письма не удалась
        /// </summary>
        public string FailedMessage { get; set; }
        /// <summary>
        /// Когда создана
        /// </summary>
        public DateTime Create { get; set; } = DateTime.UtcNow;
    }
}
