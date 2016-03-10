using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using ObscureDesign.Data;

namespace ObscureDesign.Data
{
    /// <summary>
    /// For database migrations only
    /// </summary>
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// 1. Loads configurations
        /// </summary>
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().AddUserSecrets().Build();
        }

        /// <summary>
        /// 2. This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
        }
    }
}
