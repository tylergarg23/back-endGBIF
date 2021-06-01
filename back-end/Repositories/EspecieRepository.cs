using back_end.Data;
using back_end.Entities;
using back_end.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositories
{
    public class EspecieRepository: IEspecieRepository
    {
        private readonly BD_GBIFContext _context;
        public EspecieRepository(BD_GBIFContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Entities.Especie>> GetEspecies()
        {
            var especies = await _context.Especie.ToListAsync();

            return (IEnumerable<Entities.Especie>)especies;

        }

        //public Task<Entities.Especie> InsertarEspecie()
        //{
        //    using (SqlConnection db = new SqlConnection(_context)
        //    {

        //    }
        //}




    }
}
