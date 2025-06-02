var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

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
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
});


app.UseAuthorization();

app.MapControllers();

app.Run();