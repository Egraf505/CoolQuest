using CoolQuest.backend;
using CoolQuest.DbContext.Context;
using Microsoft.EntityFrameworkCore;

CreateHostBuilder(args).Build().Run();

 static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
 .ConfigureWebHostDefaults(webBuilder =>
 {
     webBuilder.UseStartup<Startup>();
 });
