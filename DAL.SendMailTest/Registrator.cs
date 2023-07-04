using DAL.VideoGamesTest.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.SendMailTest.MsSLQ
{

    /// <summary>
    /// Класс регистрирует и добавляет миграцию, таки образом мы можем рабоать с лююбой бд,которая поддерживает EF
    /// </summary>
    public static class Registrator
    {
        /// <summary>
        /// Подключение и накат миграции MsSql 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connection_string"></param>
        public static void UseSqlServer(this IServiceCollection services,string connection_string)
        {
            if (connection_string is null)
            {
                //logger
                return;
            }
            services.AddDbContext<MailContext>(opt => opt.UseSqlServer(connection_string, o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)));
        }
    }
}