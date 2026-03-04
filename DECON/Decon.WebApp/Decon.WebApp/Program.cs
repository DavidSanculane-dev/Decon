using Decon.WebApp.Client.Pages;
using Decon.WebApp.Components;
using Decon.Infrastructure.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Infra: DbContext / Postgres
builder.Services.AddInfrastructure(builder.Configuration);

// Blazor + restante pipeline padrão do template...
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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
   .AddInteractiveServerRenderMode()
   .AddInteractiveWebAssemblyRenderMode();

app.Run();

