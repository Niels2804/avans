using BlazorMqttDatabase.Services;
using robot_app.Components;
using SimpleMqtt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var simpleMqttClient = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ("web");
builder.Services.AddSingleton<SqlUserRepository>(); 
builder.Services.AddSingleton<MqttExternalMessageProcessingService>(); 
builder.Services.AddSingleton<MqttData>(); 
builder.Services.AddSingleton(simpleMqttClient); 
builder.Services.AddHostedService<MqttMessageProcessingService>();

#if DEBUG
    builder.Services.AddSassCompiler();
#endif

var app = builder.Build();

// Verplichte asynchrone initialisatie, zodat de database gegevens goed zijn ingeladen bij het eerste keer inladen van de pagina
using (var scope = app.Services.CreateScope())
{
    var sqlUserRepository = scope.ServiceProvider.GetRequiredService<SqlUserRepository>();

    Console.WriteLine("Initialiseren van gebruikersdata...");
    await sqlUserRepository.InitializeData();
    Console.WriteLine("Data succesvol geladen!");
}

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