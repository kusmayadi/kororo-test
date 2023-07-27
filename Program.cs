using Kentico.Web.Mvc;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Enable desired Kentico Xperience features
builder.Services.AddKentico(features =>
{
    // features.UsePageBuilder();
    // features.UseActivityTracking();
    // features.UsePageRouting();
    // features.UseEmailStatisticsLogging();
    // features.UseEmailMarketing();
});

builder.Services.AddAuthentication();
// services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.InitKentico();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseAuthentication();


app.UseKentico();

// app.UseAuthorization();

app.Kentico().MapRoutes();
app.MapGet("/", () => "The KororoTest site has not been configured yet.");

app.Run();