using Api;
using Application.UseCases.Horaires;
using Application.UseCases.Prestations;
using Application.UseCases.Travails;
using Domain;
using Infrastructure;
using Infrastructure.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// I, Repertory
builder.Services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();
builder.Services.AddScoped<DBContextProvider>();

// Travails
builder.Services.AddScoped<ITravailsRepository, EfTravailsRepository>();

// Horaires
builder.Services.AddScoped<IHorairesRepository, EfHorairesRepository>();

// Prestations
builder.Services.AddScoped<IPrestationsRepository, EfPrestationsRepository>();

// Use Cases Travails
builder.Services.AddScoped<UseCaseCreateTravails>();
builder.Services.AddScoped<UseCaseUpdateTravails>();
builder.Services.AddScoped<UseCaseDeleteTravails>();
builder.Services.AddScoped<UseCaseFetchAllTravails>();
builder.Services.AddScoped<UseCaseFetchByIdTravails>();
builder.Services.AddScoped<UseCaseFetchFilterTravails>();

// Use Cases Horaires
builder.Services.AddScoped<UseCaseCreateHoraires>();
builder.Services.AddScoped<UseCaseUpdateHoraires>();
builder.Services.AddScoped<UseCaseDeleteHoraires>();
builder.Services.AddScoped<UseCaseFetchAllHoraires>();
builder.Services.AddScoped<UseCaseFetchByIdHoraires>();
builder.Services.AddScoped<UseCaseFetchFilterHoraires>();

// Use Cases Prestations
builder.Services.AddScoped<UseCaseCreatePrestations>();
builder.Services.AddScoped<UseCaseUpdatePrestations>();
builder.Services.AddScoped<UseCaseDeletePrestations>();
builder.Services.AddScoped<UseCaseFetchAllPrestations>();
builder.Services.AddScoped<UseCaseFetchNextPrestations>();
builder.Services.AddScoped<UseCaseFetchNextPrestation>();
builder.Services.AddScoped<UseCaseFetchNextSalary>();
builder.Services.AddScoped<UseCaseFetchByIdPrestations>();
builder.Services.AddScoped<UseCaseFetchFilterPrestations>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", policyBuilder =>
    {
        /*
        policyBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        */
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
    // On désactive le redirection
    // A changer pour le SSL
    app.UseHttpsRedirection();

app.UseCors("Dev");
app.UseAuthorization();
app.MapControllers();
app.Run();