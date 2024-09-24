using Microsoft.EntityFrameworkCore;
using T2305M_API.Entities;
using T2305M_API.Services.Implements;
using T2305M_API.Services;
using T2305M_API.Repositories.Implements;
using T2305M_API.Repositories;
//using T2305M_API.Services.Implements;
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
//builder.Services.AddScoped<SearchServiceImpl>(); 
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICultureRepository, CultureRepository>();
builder.Services.AddScoped<ICultureService, CultureService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<SearchServiceImpl>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICreatorRepository, CreatorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

//Data seeding section

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