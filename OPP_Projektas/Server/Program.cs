using Microsoft.AspNetCore.ResponseCompression;
using OPP_Projektas.Server.GameHubs;
using OPP_Projektas.Server.Services;
using OPP_Projektas.Server.Services.RouletteServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//-----for signalR is MSofto, nieko custom
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
    options.MimeTypes = ResponseCompressionDefaults
    .MimeTypes
    .Concat(new[] { "application/octet-stream" })
);
//-----
builder.Services.AddSingleton<IRouletteServices, RouletteServices>();
builder.Services.AddSingleton<BlackJackTableServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseResponseCompression();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

//hub'u endpoint'ai
app.MapHub<SlotsHub>("/slotshub");
app.MapHub<BlackJackHub>("/blackjackhub");
app.MapHub<RouletteHub>("/roulettehub");
app.MapHub<ChatHub>("/chathub");

app.Run();
