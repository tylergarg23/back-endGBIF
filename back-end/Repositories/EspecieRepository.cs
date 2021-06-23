using back_end.Data;
using back_end.Entities;
using back_end.Interfaces;
using back_end.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static back_end.Entities.Especie;

namespace back_end.Repositories
{
    public class EspecieRepository: IEspecieRepository
    {
        private readonly EspecieContexto _context;

        private readonly string _connectionString;

        private static readonly string urlSpecie = "https://api.gbif.org/v1/species";
        public EspecieRepository(EspecieContexto context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("ConexionText");
        }
        //public async Task<IEnumerable<Entities.Especie.Result>> GetEspecies()
        //{
        //    var especies = await _context.Especie.ToListAsync();

        //    return (IEnumerable<Entities.Especie.Result>)especies;

        //}
        public async Task<Result[]> GetEspecies()
        {
            //var urlSpecie = "https://api.gbif.org/v1/species";
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(urlSpecie);
                Rootobject especies = JsonConvert.DeserializeObject<Rootobject>(response);

                return especies.results;
            }

        }

        public async Task<IEnumerable<EspecieModel>> GetEspecie()
        {
            var especie = await _context.EspecieItems.ToListAsync();
            return especie;
        }
        
        //Metodos con Procedimientos almacenados sin EntityFramework
        public async Task<List<EspecieModel>> GetAllEspecie()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_getAllEspecie", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<EspecieModel>();
                    await sql.OpenAsync();

                    using ( var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            response.Add(MapToEspecie(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private EspecieModel MapToEspecie(SqlDataReader reader)
        {
            return new EspecieModel()
            {
                Id = (int)reader["Id"],
                Key = (int)reader["Key"],
                Kingdom = reader["Kingdom"].ToString(),
                ScientificName = reader["ScientificName"].ToString(),
                CanonicalName = reader["CanonicalName"].ToString(),
                NameType = reader["NameType"].ToString(),
                Origin = reader["Origin"].ToString(),
                NumDescendants = (int)reader["NumDescendants"]
            };
        }


        public async Task InsertEspecie(EspecieModel value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insertarEspecie", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@key", value.Key));
                    cmd.Parameters.Add(new SqlParameter("@kingdom", value.Kingdom));
                    cmd.Parameters.Add(new SqlParameter("@scientificName", value.ScientificName));
                    cmd.Parameters.Add(new SqlParameter("@canonicalName", value.CanonicalName));
                    cmd.Parameters.Add(new SqlParameter("@nameType", value.NameType));
                    cmd.Parameters.Add(new SqlParameter("@origin", value.Origin));
                    cmd.Parameters.Add(new SqlParameter("@numDescendants", value.NumDescendants));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }







        //public async Task<Result[]> GetEspecie(int id)
        //{
        //    //using (var especie = new HttpClient())
        //    //{
        //    //    especie.BaseAddress = new Uri(urlSpecie);
        //    //    var Respuesta = especie.GetAsync($"/{id}").Result;
        //    //    if (Respuesta.IsSuccessStatusCode)
        //    //    {
        //    //        var JSONResultado = Respuesta.Content.ReadAsStringAsync().Result;
        //    //         return JsonConvert.DeserializeObject<Result[]>(JSONResultado);
        //    //    }
        //    //    return null;
        //    //}

        //    var es = new Entities.Especie.Rootobject();
        //    var especie = es.results.FirstOrDefault(x => x.key == id);

        //    return null;
        //}

    }
}
