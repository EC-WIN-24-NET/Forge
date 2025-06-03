using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Let's add support for Entity Framework Core and connect to a database
// --- Add Azure Key Vault configuration ---
var keyVaultUri = builder.Configuration["EcWin24KeyVaultUri"];

if (
    !string.IsNullOrEmpty(keyVaultUri)
    && Uri.TryCreate(keyVaultUri, UriKind.Absolute, out var validUri)
)
{
    builder.Configuration.AddAzureKeyVault(validUri, new DefaultAzureCredential());
}
else
{
    Console.WriteLine("Key Vault URI is not valid");
}

// --- End of Azure Key Vault configuration ---

var connectionString = builder.Configuration.GetConnectionString("SQLServerAzure");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();

// Adding support for CORS
builder.Services.AddCors(options =>
{
    // Adding a new policy
    options.AddPolicy(
        "AllowAllNoSecurity",
        policy =>
        {
            // Minimal without security...duh
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        }
    );
});

app.UseAuthorization();

app.MapControllers();

app.Run();
