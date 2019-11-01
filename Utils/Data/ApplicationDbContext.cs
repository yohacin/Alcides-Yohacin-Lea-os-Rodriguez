using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

//local

using Entities;


namespace Data
{

    public class ApplicationDbContext : IdentityDbContext<EntidadBase>
    { 
        //public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // if (!optionsBuilder.IsConfigured)
            //     optionsBuilder.UseSqlServer("Server=172.16.10.42\\Desarrollo2014;User ID=sa;Password=Desarrollo2014.;Database=bd_Jugos");
#if (DEBUG)
            optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLoggerFactory(LoggerFactory);
#endif
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            //quuitando Campos para no requeridos en BASE 


            ///llaves copuestas
        }
            
           
        //------------------------------- Cliente
        public DbSet<Entities.Usuario> Usuario { get; set; }
        public DbSet<Entities.Movie> Movie { get; set; }
        


    }






}
