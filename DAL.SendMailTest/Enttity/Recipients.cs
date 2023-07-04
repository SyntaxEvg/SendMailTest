using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.SendMailTest.Enttity
{
    [Table(nameof(Recipients), Schema = "Logger")]
    [Index(nameof(Recipient))]
    public class Recipients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        ///  строка, содержащая текст письма
        /// </summary>
        public string Recipient { get; set; }

        public virtual Mail Mail { get; set; }
    }
}
