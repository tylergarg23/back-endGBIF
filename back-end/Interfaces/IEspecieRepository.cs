using back_end.Entities;
using back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static back_end.Entities.Especie;

namespace back_end.Interfaces
{
    public interface IEspecieRepository 
    {
        //Task<IEnumerable<Entities.Especie.Result>> GetEspecies()
        Task<Result[]> GetEspecies();
        //Task<Result[]> GetEspecie(int id);

        //EspecieModel - GET
        Task<IEnumerable<EspecieModel>> GetEspecie();

        //Metodo Store Procedure
        Task<List<EspecieModel>> GetAllEspecie();
        Task InsertEspecie(EspecieModel value);
    }
}
