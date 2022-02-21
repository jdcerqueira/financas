using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using financas_core;
using Newtonsoft.Json.Linq;

namespace financas_border_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FontesController : ControllerBase
    {
        [HttpGet]
        public List<Fonte> Get()
        {
            return financas_core.Fonte.listaFontesSemFiltro();
        }

        [HttpPost("criaFonte")]
        public String[] Post([FromBody] String _fonteJson)
        {
            Fonte fonte = Fonte.jsonToFonte(_fonteJson);
            return new String[]
            {
                fonte.ToString()
            };
        }
    }
}
