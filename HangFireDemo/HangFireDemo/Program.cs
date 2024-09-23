using Hangfire;

namespace HangFireDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("HangFireConnection");
            builder.Services.AddHangfire(configuration => configuration.UseSqlServerStorage(connectionString));
            builder.Services.AddHangfireServer();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseHangfireDashboard();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Schedule a recurring job
            RecurringJob.AddOrUpdate("my-recurring-job", () => PerformTask(), Cron.Minutely);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        // Make the method static
        public static void PerformTask()
        {
            Console.WriteLine($"Task Performed at {DateTime.Now}");
        }
    }
}
