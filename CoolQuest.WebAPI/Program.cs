using CoolQuest.DbContext.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Строка подключение
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CoolQuestContex>(options => options.UseSqlServer(connection));

// Аутенфикация

//Разрешение CORS
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
    }));

// Контроллеры
builder.Services.AddControllers().AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
