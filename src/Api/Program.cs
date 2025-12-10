var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // Swagger için gerekli
builder.Services.AddSwaggerGen();

// Uygulama servislerin (örnek, sen kendine göre deðiþtirirsin)
// builder.Services.AddApplication();
// builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Swagger / SwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware pipeline
app.UseHttpsRedirection();

// Örnek endpoint (sen kendi gerçek endpoint’lerini koyacaksýn)
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();