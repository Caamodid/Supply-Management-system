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
        )
    );

// ================================
// 2️⃣ CORS (FIXED & IIS-SAFE)
// ================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("KahiyeApp", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost",
                "http://localhost:3000",
                "http://127.0.0.1"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
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
    app.UseSwaggerUI();
}

// ================================
// 6️⃣ HTTPS (PRODUCTION ONLY)
// ================================
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// ================================
// 7️⃣ 🔥 REQUIRED FOR CORS
// ================================
app.UseRouting();

// ================================
// 8️⃣ 🔥 CORS MUST BE HERE
// ================================
app.UseCors("KahiyeApp");

// ================================
// 9️⃣ 🔥 ALLOW PREFLIGHT (OPTIONS)
// ================================
app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Options)
    {
        context.Response.StatusCode = StatusCodes.Status204NoContent;
        return;
    }

    await next();
});

// ================================
// 🔟 Auth AFTER CORS
// ================================
app.UseAuthentication();
app.UseAuthorization();

// ================================
// 1️⃣1️⃣ Static files (if any)
// ================================
app.UseDefaultFiles();
app.UseStaticFiles();

// ================================
// 1️⃣2️⃣ API & routing
// ================================
app.MapGet("/api/health", () =>
{
    return Results.Ok(new { status = "ok" });
});

app.MapControllers();
app.MapFallbackToFile("index.html");

// ================================
// 1️⃣3️⃣ Seeder (DEV ONLY)
// ================================
if (app.Environment.IsDevelopment())
{
    await app.UseIdentitySeederAsync();
}

// ================================
// 1️⃣4️⃣ Run
// ================================
app.Run();
