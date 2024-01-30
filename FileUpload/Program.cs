using FileUpload.Models;
using FileUpload.Services;

namespace FileUpload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<FileContext>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IFileService, FileMuveletek>();
            var app = builder.Build();
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            app.MapControllers();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoKereskedes API V1");
                c.RoutePrefix = string.Empty;
            });



            app.Run();
        }
    }
}
