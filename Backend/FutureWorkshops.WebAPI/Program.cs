using FutureWorkshops.Infrastructure.Contexts;
using FutureWorkshops.Shared.Interfaces;
using FutureWorkshops.WebAPI.DI;
using FutureWorkshops.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Retrieve the configuration object
var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
// Load allowed origins from configuration
var allowedOrigins = configuration["AllowedOrigins"]
				.Split(",", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
// Add CORS policy
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigins", builder =>
	{
		//App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
		//builder.AllowAnyOrigin()
		builder.WithOrigins(
			allowedOrigins
			)
			.SetIsOriginAllowedToAllowWildcardSubdomains()
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials();
	});
});
// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Future Workshops.API", Version = "v1" });
	//we can set configurations for JWT tokens in here as well
});
// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register other services (e.g., container configuration)
ContainerConfiguration.Configure(builder.Services, configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Custom exception handling
using (var scope = app.Services.CreateScope())
{
	var logger = scope.ServiceProvider.GetRequiredService<ILoggerService>();
	app.ConfigureExceptionHandler(logger);
}
// Production CORS policy with restricted origins
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllers();
// Run database migrations
UpdateDatabase(app);
app.Run();


// Database migration logic
static void UpdateDatabase(IApplicationBuilder app)
{
	using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
	{
		using (var context = serviceScope.ServiceProvider.GetService<FutureWorkshopsContext>())
		{
			context.Database.Migrate();
		}
	}
}