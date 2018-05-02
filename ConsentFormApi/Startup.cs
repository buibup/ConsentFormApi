using ConsentFormApi.Common;
using ConsentFormApi.Repository;
using ConsentFormApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsentFormApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var config = new ConnectionStrings();
            Configuration.Bind("ConnectionStrings", config);
            services.AddSingleton(config);

            services.AddMvc();

            services.AddTransient<ICustomerSurveyRepository, CustomerSurveyRepository>();
            services.AddTransient<ISurveyRepository, SurveyRepository>();
            
            services.AddTransient<ICustomerSurveyService, CustomerSurveyService>();
            services.AddTransient<ISurveyChartsService, SurveyChartsService>();
            services.AddTransient<ISurveyDataService, SurveyDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
