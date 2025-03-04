var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();

var supabaseUrl = builder.Configuration["Supabase:SupabaseUrl"];
var supabaseKey = builder.Configuration["Supabase:SupabaseKey"];
if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
{
    throw new InvalidOperationException("Supabase URL или KEY не настроены в конфигурации.");
}

var supabase = new Supabase.Client(
    supabaseUrl,
    supabaseKey,
    new Supabase.SupabaseOptions { AutoConnectRealtime = true }
);

builder.Services.AddSingleton(supabase);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
