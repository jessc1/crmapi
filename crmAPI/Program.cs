using crmAPI.Models;
using crmAPI.Repositories;
using crmAPI.Services;

namespace crmAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder =
                WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddControllers();
            var app = builder.Build();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}