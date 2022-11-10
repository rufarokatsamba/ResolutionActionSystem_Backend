using Microsoft.OpenApi.Models;
using ResolutionActionSystem.Application;
using ResolutionActionSystem.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    //c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    //{
    //    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
    //    Enter 'Bearer' [space] and then your token in the text input below.
    //    \r\n\r\nExample: 'Bearer 12345abcdef' ",
    //    Name = "Authorization",
    //    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer"
    //});

    //c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            },
    //            Scheme = "oauth2",
    //            Name = "Bearer",
    //            In = ParameterLocation.Header,
    //        },
    //        new List<string>()
    //    }
    //});

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Resolution Action System Api",
    });
});


builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
