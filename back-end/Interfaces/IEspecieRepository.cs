using back_end.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Interfaces
{
    public interface IEspecieRepository 
    {
        Task<IEnumerable<Entities.Especie>> GetEspecies();
    }
}
