using Challenge_Innov8Tech.Infrastructure;
using Challenge_Innov8Tech.Interfaces;
using Challenge_Innov8Tech.Repositories;
using Challenge_Innov8Tech.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationContext>(options => {
    options.UseOracle(builder.Configuration["ConnectionStrings:Oracle"]);
});

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteAplicationService, ClienteApplicationService>();
builder.Services.AddTransient<IRamoRepository, RamoRepository>();
builder.Services.AddTransient<IRamoAplicationService, RamoAplicationService>();

builder.Services.AddTransient<IClienteService, ClienteService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
