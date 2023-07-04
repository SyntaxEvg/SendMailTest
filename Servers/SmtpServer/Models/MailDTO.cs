using System.Text.Json.Serialization;

namespace SmtpServer.Models
{
    /// <summary>
    /// Необходимый минимум для письма 
    /// </summary>
    public class MailDTO
    {
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
        public List<string> Recipients { get; set; }
        /// <summary>
        /// строка, указывающая результат отправки письма. Может принимать значения "OK" или "Failed"
        /// </summary>
        [JsonIgnore]
        public string Result { get; set; }
        /// <summary>
        /// строка, содержащая сообщение об ошибке, если отправка письма не удалась
        /// </summary>
        [JsonIgnore]
        public string FailedMessage { get; set; }
    }
}