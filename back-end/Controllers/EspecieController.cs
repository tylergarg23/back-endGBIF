using back_end.Entities;
using back_end.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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

        [HttpGet("especies")]
        public async Task<Especie> ListarEspecies()
        {
            //var especies = await _especieRepository.GetEspecies();
            //return Ok(null);

            string url = "https://api.gbif.org/v1/species";
            dynamic content = new WebClient().DownloadString(url);
            Especie obj = JsonConvert.DeserializeObject<Especie>(content.result);
            return obj;

            
       

        }
    }
}
