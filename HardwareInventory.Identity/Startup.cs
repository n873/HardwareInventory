using IdentityServer4;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HardwareInventory.Identity
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;database=IdentityServer4.Quickstart.EntityFramework-2.0.0;trusted_connection=yes;";
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddMvc();

            services.AddIdentityServer();
                //.AddDeveloperSigningCredential()
                //.AddInMemoryApiResources(Config.GetApiResources())
                //.AddInMemoryClients(Config.GetClients())
                //.AddTestUsers(Config.GetUsers())
                //.AddConfigurationStore(options =>
                //{
                //    options.ConfigureDbContext = builder =>
                //        builder.UseSqlServer(connectionString,
                //            sql => sql.MigrationsAssembly(migrationsAssembly));
                //})
                //.AddOperationalStore(options =>
                //{
                //    options.ConfigureDbContext = builder =>
                //        builder.UseSqlServer(connectionString,
                //            sql => sql.MigrationsAssembly(migrationsAssembly));

                //    // this enables automatic token cleanup. this is optional.
                //    options.EnableTokenCleanup = true;
                //    options.TokenCleanupInterval = 30;
                //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }

        //private void InitializeDatabase(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

        //        var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        //        context.Database.Migrate();
        //        if (!context.Clients.Any())
        //        {
        //            foreach (var client in Config.GetClients())
        //            {
        //                context.Clients.Add(client.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        if (!context.IdentityResources.Any())
        //        {
        //            foreach (var resource in Config.GetIdentityResources())
        //            {
        //                context.IdentityResources.Add(resource.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        if (!context.ApiResources.Any())
        //        {
        //            foreach (var resource in Config.GetApiResources())
        //            {
        //                context.ApiResources.Add(resource.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }
        //    }
        //}
    }
}
