using back_end.Entities;
using back_end.Interfaces;
using back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static back_end.Entities.Especie;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieRepository _especieRepository;

        public EspecieController(IEspecieRepository especieRespository)
        {
            _especieRepository = especieRespository;
        }

        //[HttpGet("especies")]
        //public async Task<Especie> ListarEspecies()
        //{
        //    //var especies = await _especieRepository.GetEspecies();
        //    //return Ok(null);

        //    dynamic content = new WebClient().DownloadString(url);
        //    Especie obj = JsonConvert.DeserializeObject<Especie>(content);
        //    return obj;

        //}

        [HttpGet("especie")]
        public async Task<IActionResult> GetEspecieItems()
        {
            var especie = await _especieRepository.GetEspecie();
            return Ok(especie);
        }


        [HttpGet("consulta-especie")]
        public async Task<IActionResult> GetEspecies()
        {
            var especies = await _especieRepository.GetEspecies();
            return Ok(especies);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetEspecie(int id)
        //{
        //    var especie = await _especieRepository.GetEspecie(id);
        //    return Ok(especie);
        //}

        [HttpGet("getallespecie")]
        public async Task<List<EspecieModel>> GetAllEspecie()
        {
            return await _especieRepository.GetAllEspecie();
        }

        [HttpPost]
        public async Task Post([FromBody] EspecieModel value)
        {
            await _especieRepository.InsertEspecie(value);
        }

    }
}
