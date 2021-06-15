using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd
{
    public class AplicationDbContext: DbContext 
    {
        public DbSet<WorkersApsi> WorkersApsi { get; set; }
        public DbSet<Login> Login { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext>options): base(options)
        {


        }

    }
}
