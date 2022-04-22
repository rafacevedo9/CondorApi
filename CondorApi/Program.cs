var builder = WebApplication.CreateBuilder(args);
// Constante para configurar Cors
const string CorsConfiguration = "_corsConfiguration";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Habilitamos los cors, en este caso solo acptamos el puerto 4200, donde corre angular por defecto.
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: CorsConfiguration,
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Activiamos Cors
app.UseCors(CorsConfiguration);

app.MapControllers();

app.Run();
