using EmployeeAPI.Infrastructure.Data;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Application.Services;
using EmployeeAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Graphql.Queries;
using EmployeeAPI.Graphql.Mutations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<EmployeeQuery>()
    .AddMutationType<EmployeeMutation>();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("CONNECTION STRING: " + conn);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGraphQL();

app.Run();
