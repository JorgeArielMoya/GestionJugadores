using GestionJugadores.Components;
using GestionJugadores.DAL;
using GestionJugadores.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Inyeccion de Api
builder.Services.AddHttpClient("ApiGestionHuacales", client =>
{
    client.BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/");
});

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//Obtenemos el ConStr para utilizarlo en el contexto
var ConnectionString = builder.Configuration.GetConnectionString("SqlConStr");

//Agregamos el contexto al builder
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConnectionString));

//Inyectamos el service
builder.Services.AddScoped<JugadoresService>();
builder.Services.AddScoped<PartidasService>();
builder.Services.AddScoped<MovimientosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
