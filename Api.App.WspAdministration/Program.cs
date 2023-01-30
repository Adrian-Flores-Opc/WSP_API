using Microsoft.OpenApi.Models;
using WSP.ABSTRACTION.DATAACCESS;
using WSP.ABSTRACTION.LOGGER;
using WSP.ABSTRACTION.SECRYPT;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogger();
builder.Services.AddDataBase();
builder.Services.AddSecrypt();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
