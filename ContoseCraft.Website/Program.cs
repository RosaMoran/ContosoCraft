using ContosoCrafts.WebSite.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddTransient<JsonFileProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub();


/*app.MapGet("/products", (context) =>
{
    IEnumerable products = app.Services.GetService<JsonFileProductService>().GetProducts();
    var json = JsonSerializer.Serialize<IEnumerable>(products);
    return context.Response.WriteAsync(json);
});*/

app.Run();