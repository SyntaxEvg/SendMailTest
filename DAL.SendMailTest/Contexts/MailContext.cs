using DAL.SendMailTest.Enttity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VideoGamesTest.Contexts
{
    public class MailContext : DbContext
    {
        public DbSet<Mail> Mail { get; set; }

        public MailContext(DbContextOptions<MailContext> opt) : base(opt)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
    }
}
