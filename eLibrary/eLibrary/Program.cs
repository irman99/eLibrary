using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;
using eLibrary.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dbIB190096Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IKnjigaService, KnjigaService>();
builder.Services.AddScoped<IKorisnikService, KorisnikService>();
builder.Services.AddScoped<IZanrService, ZanrService>();
builder.Services.AddScoped<IKomentarService, KomentarService>();
builder.Services.AddScoped<IOcjeneService, OcjeneService>();
builder.Services.AddScoped<IMedaljaService, MedaljaService>();

builder.Services.AddScoped<IFajloviKnjigeService>(provider =>
{
    var context = provider.GetRequiredService<dbIB190096Context>();
    var fileUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Database", "UploadovaneKnjige");
    return new FajloviKnjigeService(context, fileUploadPath);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // To serve Swagger UI at the app's root
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
