using ChurchManagementApi.Extentions;
using ChurchManagementApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration, builder.Environment.IsDevelopment());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors();

app.UseMiddleware<ApiExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
