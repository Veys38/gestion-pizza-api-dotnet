
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using GestionPizza.API.Utils;
using GestionPizza.BLL.Services;
using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.BLL.Utils;
using GestionPizza.DAL.Context;
using GestionPizza.API.Datas;
using GestionPizza.DAL.Repositories;
using GestionPizza.DAL.Repositories.Interfaces;
using System.Threading.Tasks;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

    c.AddSecurityRequirement(securityRequirement);

});

builder.Services.AddDbContext<LibraryDbContext>();
// 🔐 JWT Authentication
var jwtConfig = builder.Configuration.GetSection("TokenInfo");
var secretKey = jwtConfig.GetValue<string>("secret");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtConfig.GetValue<string>("issuer"),

            ValidateAudience = true,
            ValidAudience = jwtConfig.GetValue<string>("audience"),

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// 🔐 Policy "Auth"
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Auth", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");
    });
});

builder.Services.AddCors(c => c.AddDefaultPolicy(
    p=>p.AllowAnyOrigin()
    ));


// 🔧 Repositories
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPizzeriaRepository, PizzeriaRepository>();


// 🔧 Services
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPizzeriaService, PizzeriaService>();
builder.Services.AddScoped<JwtUtils>();
builder.Services.AddScoped<IGeocodingService, GeocodingService>();





var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();  
app.UseAuthorization();  

app.UseCors();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    await SeedData.InitializeAsync(scopedProvider);
}



await app.RunAsync();
