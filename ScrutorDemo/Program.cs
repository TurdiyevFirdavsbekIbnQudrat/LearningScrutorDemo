using Enyim.Caching;
using Enyim.Caching.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ScrutorDemo;
using ScrutorDemo.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ScrutorDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    , providerOptions => providerOptions.EnableRetryOnFailure());
});
builder.Services.AddEnyimMemcached(o => o.Servers = new List<Server> { new Server { Address = "localhost", Port = 11211 } });

builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
//builder.Services.AddScoped<IGeneral<User>, UserRepository>();
//builder.Services.AddScoped<IGeneral<Car>, CarRepository>();

builder.Services.Scan(x=>x.FromAssemblies(typeof(IGeneral<>).Assembly)
                        .AddClasses(c=>c.AssignableTo(typeof(IGeneral<>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
