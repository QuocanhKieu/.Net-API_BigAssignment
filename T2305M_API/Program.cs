using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;
using T2305M_API.Services;
var builder = WebApplication.CreateBuilder(args);

// Add CORS policy access
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        //policy.WithOrigins("http://localhost:3000");
        policy.AllowAnyOrigin();
        //policy.WithMethods("POST");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

// connect db
T2305mApiContext.ConnectionString = builder.Configuration.GetConnectionString("T2305M_API");
// attach the DbContext for Dependency Injection Ready
builder.Services.AddDbContext<T2305mApiContext>(
    options => options.UseSqlServer(T2305mApiContext.ConnectionString)
);
// Add services to the container.
builder.Services.AddScoped<SearchService>(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Data seeding section
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<T2305mApiContext>();

    if (context != null)
    {
        DatabaseSeeder.Seed(context);
    }
    else
    {
        // Log an error or handle the situation where the context is null
        throw new InvalidOperationException("T2305mApiContext is not available.");
    }
}


app.Run();