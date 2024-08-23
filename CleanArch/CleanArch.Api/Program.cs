
using ClassArch.Infra.IoC;
using CleanArch.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("UniversityIdentityDBConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));


// Add Univeristy to the container.
var uniConnectionString = builder.Configuration.GetConnectionString("UniversityDBConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<UniversityDBContext>(options =>
    options.UseSqlServer(uniConnectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(typeof(StartupBase));
//builder.Services.AddMediatR(typeof(IStartup));
//builder.Services.AddSwaggerGen(op =>
//{
//    op.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.OpenApiInfo { RouteTemplate = "University Api", SerializeAsV2 = "v1" });
//});
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//builder.Services.AddMediatR(typeof(Program));


DependencyContainer.RegisterService(builder.Services);



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "University Api V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
