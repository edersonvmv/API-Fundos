using AutoMapper;
using CaseItau.API.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mapper => mapper.AddProfile(new AutoMapperConfig()));
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.ResolveDependencies()
                .ConexaoDatabase(builder.Configuration)
                .AddJwtAuthentication(builder.Configuration)
                .AddSwaggerConfiguracao()
                .AddFluentValidation()
                .AddSingleton(mapper);

builder.AddSerilogConfiguration(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "CaseItau V1"));

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();
