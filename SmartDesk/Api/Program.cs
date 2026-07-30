using Api.AuthOptions;
using Api.Services;
using Application.Behaviors;
using Application.Commands.CreateRoom;
using Application.Interfaces;
using Application.Interfaces.ExceptionHandlers;
using FluentValidation;
using Infrastructure;
using Infrastructure.Options;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using Polly;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddDbContext<SmartDeskDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ISmartDeskDbContext, SmartDeskDbContext>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddSingleton<IExternalNotificationService, ExternalNotificationService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateRoomCommand).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    });
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssembly(typeof(CreateRoomCommand).Assembly);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddHttpClient<IExternalNotificationService, ExternalNotificationService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(20);
})
.AddTransientHttpErrorPolicy(policyBuilder =>
    policyBuilder.WaitAndRetryAsync(
        retryCount: 3,
        sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)))
);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptions.AUDIENCE,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
