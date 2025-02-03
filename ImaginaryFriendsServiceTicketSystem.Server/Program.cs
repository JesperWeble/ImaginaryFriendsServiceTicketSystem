using ImaginaryFriendsServiceTicketSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ImaginaryFriendsServiceTicketSystem.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var conStr = builder.Configuration.GetConnectionString("dbCon");
            builder.Services.AddDbContext<TicketContext>(options =>
            {
                options.UseMySql(conStr, ServerVersion.AutoDetect(conStr));
            });

            // Add CORS policy to the services collection
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("https://localhost:59639")  // Allowed origin
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigin");  // Apply the policy

            app.MapControllers();

            app.MapFallbackToFile("/index.html");


            // Adds default Level, Status and Sla to DB, with some extra mockdata.
            //PopulateDB.Populate(conStr);

            app.Run();

            
        }
    }
}
