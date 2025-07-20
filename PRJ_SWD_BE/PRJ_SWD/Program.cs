using PRJ_SWD.DAL.Infracstructure;
using PRJ_SWD.Business.Service.ReservationService;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using PRJ_SWD.Business.Service.BlogService;
using PRJ_SWD.Business.Service.ServiceService;
using PRJ_SWD.Business.Service.StaffService;
using PRJ_SWD.Business.Service.MedicineService;
using PRJ_SWD.Business.Service.MedicinePrescriptionService;

namespace PRJ_SWD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IBlogService, BlogService>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<ServiceService>();
            builder.Services.AddScoped<ServiceRepository>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<StaffService>();
            builder.Services.AddScoped<StaffRepository>();
            builder.Services.AddScoped<IMedicineService, MedicineService>();
            builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
            builder.Services.AddScoped<IMedicinePrescriptionService, MedicinePrescriptionService>();
            builder.Services.AddScoped<IMedicinePrescriptionRepository, MedicinePrescriptionRepository>();
            builder.Services.AddDbContext<PrjSwdContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
