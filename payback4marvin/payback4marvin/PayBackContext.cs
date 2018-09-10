using Microsoft.EntityFrameworkCore;
using payback4marvin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payback4marvin
{
    public class PayBackContext : DbContext
    {
        public PayBackContext()
        {

        }
        public PayBackContext(DbContextOptions<PayBackContext> options)
                : base(options)
        {
        }


        public DbSet<Verbrecher> Verbrecher { get; set; }
        public DbSet<Vergehen> Vergehen { get; set; }

    }
}
