using back_end.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Data
{
    public class EspecieContexto: DbContext
    {
        public EspecieContexto()
        {
        }
        public EspecieContexto(DbContextOptions<EspecieContexto> options):base(options)
        {
        }

        //Crear nuestro DbSet
        public DbSet<EspecieModel> EspecieItems { get; set; }

    }
}
