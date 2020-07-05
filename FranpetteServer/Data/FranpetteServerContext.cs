using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FranpetteLib.Model;

namespace FranpetteServer.Models
{
    public class FranpetteServerContext : DbContext
    {
        public FranpetteServerContext (DbContextOptions<FranpetteServerContext> options)
            : base(options)
        {
        }

        public DbSet<FranpetteLib.Model.FUser> FUser { get; set; }
    }
}
