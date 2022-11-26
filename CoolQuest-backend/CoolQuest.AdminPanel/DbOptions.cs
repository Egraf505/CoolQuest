using CoolQuest.DbContext.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolQuest.AdminPanel
{
    internal static class DbOptions
    {
        public static DbContextOptions<CoolQuestContex> Options
        {
            get
            {
                var builder = new DbContextOptionsBuilder<CoolQuestContex>();
                return builder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString).Options;
            }
        }
    }
}
