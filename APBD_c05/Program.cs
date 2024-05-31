using APBD_c05.Models;
using APBD_c05.Services;

var builder = WebApplication.CreateBuilder(args);
        
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ITripsService, TripsService>();
builder.Services.AddScoped<IClientService, ClientsService>();

var app = builder.Build();
        
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
        
app.Run();


// dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=master;User ID=sa;Password=yourStrong(!)Password;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Context
