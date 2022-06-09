using BookMyShow.Context;

using BookMyShow.Services;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BookMyShow.Authentication;
using SimpleInjector;
using AutoMapper;
using BookMyShow.MapperClass;

var builder = WebApplication.CreateBuilder(args);
var apiCorsPolicy="ApiCorsPolicy";
builder.Services.AddMvcCore();

builder.Services.AddAutoMapper(typeof(MapperClass));

// Add services to the container.
var container=new Container();
builder.Services.AddSimpleInjector(container, options =>
 {
     options.AddAspNetCore().AddControllerActivation();
 }
);
container.Register<IMovieServices, MovieServices>(Lifestyle.Scoped);
container.Register<ISeatServices, SeatServices>(Lifestyle.Scoped);
container.Register<IShowServices, ShowServices>(Lifestyle.Scoped);
container.Register<ITheatreServices, TheatreServices>(Lifestyle.Scoped);
container.Register<ITicketServices, TicketServices>(Lifestyle.Scoped);

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


/*builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});*/
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: apiCorsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
     .AddJwtBearer(options =>
     {
         options.SaveToken = true;
         options.RequireHttpsMetadata = false;
         options.TokenValidationParameters = new TokenValidationParameters()
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidAudience = builder.Configuration["JWT:ValidAudience"],
             ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
         };
     });

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.Services.UseSimpleInjector(container);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(apiCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
