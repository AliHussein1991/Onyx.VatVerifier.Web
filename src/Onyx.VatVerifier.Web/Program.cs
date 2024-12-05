using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

using Onyx.VatVerifier.Web.Components;
using Onyx.VatVerifier.Web.Services;

var builder = WebApplication.CreateBuilder(args);

var apiBaseAddress = builder.Configuration["ApiSettings:BaseAddress"];

builder.Services.AddScoped(sp =>
{
    return new HttpClient { BaseAddress = new Uri(apiBaseAddress) };
});

// Register VatVerificationService
builder.Services.AddScoped<VatVerificationService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
