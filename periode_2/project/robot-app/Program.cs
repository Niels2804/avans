using BlazorMqttDatabase.Services;
using robot_app.Components;
using SimpleMqtt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IUserRepository>(new SqlUserRepository());
var simpleMqttClient = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ("webapp");
builder.Services.AddSingleton(simpleMqttClient); 
builder.Services.AddHostedService<MqttMessageProcessingService>();

#if DEBUG
    builder.Services.AddSassCompiler();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// 404 Middleware
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
    {
        context.Response.Clear();
        context.Response.StatusCode = 404;
        context.Response.Redirect("/Error"); // Verwijst naar mijn 404-error pagina
    }
});

app.Run();
