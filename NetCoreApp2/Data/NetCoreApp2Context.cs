using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace NetCoreApp2.Models
{
    public class NetCoreApp2Context : DbContext
    {
        public NetCoreApp2Context (DbContextOptions<NetCoreApp2Context> options)
            : base(options)
        {
        }

        public DbSet<Entities.Movie> Movie { get; set; }
    }
}
