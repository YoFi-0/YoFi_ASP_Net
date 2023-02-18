using Yofi_ASP_Net.SignalR;

namespace Yofi_ASP_Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            //use Api
            builder.Services.AddEndpointsApiExplorer();
            // use Swagger
            builder.Services.AddSwaggerGen();
            //use SignalR
            builder.Services.AddSignalR();

            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "YoFi_Sesstion";
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });
            var app = builder.Build();
            if (app!.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // use sesstion
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // signalR Clasess
            app.MapHub<MainSocket>("/MineSocket");
            // signalR Clasess

            app.Run();
        }
    }
}