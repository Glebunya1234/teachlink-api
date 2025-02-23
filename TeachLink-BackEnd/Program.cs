var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAuthorization();
builder.Services.AddSignalR();

var url = " ";
var key = " ";

if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
{
    throw new InvalidOperationException("Supabase URL или KEY не настроены в конфигурации.");
}

var supabase = new Supabase.Client(
    url,
    key,
    new Supabase.SupabaseOptions { AutoConnectRealtime = true }
);

builder.Services.AddSingleton(supabase);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
