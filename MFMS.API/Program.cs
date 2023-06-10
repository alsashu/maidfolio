using MFMS.Application.Abstraction;
using MFMS.Application.Implementation;
using MFMS.Application.Repository;
using MFMS.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<EF_DbContext>(
//        o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
//        t => t.MigrationsAssembly("MFMS.API"))
//    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Database services
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

//-----------------------------------------------------------------------
builder.Services.AddScoped<IClientProfileViewedHistoryService, ClientProfileViewedHistoryService>();
builder.Services.AddScoped<IClientProfileViewedHistoryRepository, ClientProfileViewedHistoryRepository>();

builder.Services.AddScoped<IRequirementService, RequirementService>();
builder.Services.AddScoped<IRequirementRepository, RequirementRepository>();

builder.Services.AddScoped<IMaidReviewService, MaidReviewService>();
builder.Services.AddScoped<IMaidReviewRepository, MaidReviewRepository>();

builder.Services.AddScoped<IClientSubscriptionDetailService, ClientSubscriptionDetailService>();
builder.Services.AddScoped<IClientSubscriptionDetailRepository, ClientSubscriptionDetailRepository>();

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IRoleMasterService, RoleMasterService>();
builder.Services.AddScoped<IRoleMasterRepository, RoleMasterRepository>();

builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

builder.Services.AddScoped<ISalaryRangeService, SalaryRangeService>();
builder.Services.AddScoped<ISalaryRangeRepository, SalaryRangeRepository>();

builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();

builder.Services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();
builder.Services.AddScoped<ISubscriptionTypeRepository, SubscriptionTypeRepository>();

builder.Services.AddScoped<IWorkingHourService, WorkingHourService>();
builder.Services.AddScoped<IWorkingHourRepository, WorkingHourRepository>();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

//Implement infrastructure DependencyInjection container
builder.Services.ImplementPersistence(builder.Configuration);

builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["JWT:Issuer"],
		ValidAudience = builder.Configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Key)
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseMvc();
