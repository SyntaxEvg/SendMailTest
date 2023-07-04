using Microsoft.Extensions.Configuration;
using SmtpServer.Models;
using DAL.SendMailTest.MsSLQ;
using SendMailTest.Routings;
using DAL.VideoGamesTest.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var db = builder.Configuration["ConnectionStrings:db"];

#region Services
// Чтение настроек SMTP сервера из файла конфигурации
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.UseSqlServer(db);
builder.Services.AddDbContext<MailContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.DefaultPolicyName = "default";
    opt.AddDefaultPolicy(b =>
    {
        b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

#endregion
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<MailContext>(); //
    if (context.Database.EnsureCreated())
    {
        ///бла бла ..  
    }
    await context.Database.MigrateAsync().ConfigureAwait(false);
}


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("default");

app.Routing();
app.Run();


