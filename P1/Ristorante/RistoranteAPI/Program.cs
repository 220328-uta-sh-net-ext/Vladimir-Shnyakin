using System.Text;
using Logic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RateAppDL;
using RistoranteAPI.Repository;
using Serilog;



  Log.Logger = new LoggerConfiguration()
    .WriteTo.File("../DL/user.txt").MinimumLevel.Debug().MinimumLevel.Information()
    .CreateLogger();

//const string connectionStringFilePath = "../../../../DL/connection-string.txt";
//string connectionString;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Config = builder.Configuration;
// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var key = Encoding.UTF8.GetBytes(Config["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = Config["JWT:Issuer"],
        ValidAudience = Config["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

/*builder.Services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
        JwtBearerDefaults.AuthenticationScheme);

    defaultAuthorizationPolicyBuilder =
        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
});*/

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ristorante", Version = "v1",
                        Description = "App to review restaurants" });
                    //other options

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer token')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                });
// Config.GetConnectionString("Ristorante")
builder.Services.AddScoped<IRepository>(repo => new SqlRepository(Config.GetConnectionString("Ristorante")));
builder.Services.AddScoped<ILogic, Operations>();
builder.Services.AddScoped<IJWTManagerRepository, JWTManagerRepository>();
/*builder.Services.AddIdentity(options => {
    options.ClaimIdentity.UserIdClaimType = "UserID";
});*/

builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("admin",
        authBuilder =>
        {
            authBuilder.RequireRole("admin");
        });

});

var app = builder.Build();
app.Logger.LogInformation("App Started");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});*/

app.Run();
