using CoolQuest.DbContext.Context;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using React.AspNet;

var builder = WebApplication.CreateBuilder(args);

// Строка подключение
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CoolQuestContex>(options => options.UseSqlServer(connection));

// Аутенфикация

// React
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddReact();
builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();

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

app.UseReact(config => { });
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
