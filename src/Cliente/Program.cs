using cliente.api.Extensions;
using cliente.aplicacion.Extensions;
using cliente.comun.Extensions;
using cliente.persistencia.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*****************************************
// API Version
builder.Services.AddApiVersionExtension();
builder.Services.AddClienteAplicacionExtensions();
builder.Services.AddClienteComunExtensions(builder.Configuration);
builder.Services.AddClientePersistenciaExtensions(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//*****************************************
// Middleware de errores
app.UseErrorsHandlerMiddlware();

app.MapControllers();

app.Run();
