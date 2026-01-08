using System.Text.Json.Serialization;
using WebApi;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// ================================
// 1️⃣ Register services
// ================================
builder.Services.AddWebApiServices(builder.Configuration);

// Controllers + enum as string
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter()
    ));

// ================================
// 2️⃣ CORS configuration (ENV-AWARE)
// ================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("KahiyeApp", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            // Local frontend
            policy.WithOrigins("http://localhost:3000");
        }
        else
        {
            // Production frontend (CHANGE THIS)
            policy.WithOrigins("https://your-production-domain.com");
        }

        policy.AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// ================================
// 3️⃣ Build app
// ================================
var app = builder.Build();

// ================================
// 4️⃣ Global exception handling
// ================================
app.UseGlobalExceptionHandler();

// ================================
// 5️⃣ Swagger (DEV ONLY)
// ================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentingApp API v1");
        c.RoutePrefix = "swagger";
    });
}

// ================================
// 6️⃣ HTTPS (PRODUCTION ONLY)
// ================================
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// ================================
// 7️⃣ Middleware order (IMPORTANT)
// ================================
app.UseCors("KahiyeApp");

app.UseAuthentication();
app.UseAuthorization();

// ================================
// 8️⃣ Static files (React build)
// ================================
app.UseDefaultFiles();
app.UseStaticFiles();

// ================================
// 9️⃣ Routing
// ================================
app.MapControllers();
app.MapFallbackToFile("index.html");

// ================================
// 🔟 Seeder (DEV ONLY)
// ================================
if (app.Environment.IsDevelopment())
{
    await app.UseIdentitySeederAsync();
}

// ================================
// 1️⃣1️⃣ Run app
// ================================
app.Run();
