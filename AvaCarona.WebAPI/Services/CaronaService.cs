using AvaCarona.API.Business;
using AvaCarona.API.Domain;
using AvaCarona.WebAPI.ModelView;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaCarona.WebAPI.Services
{
    [Route("api/carona")]
    public class CaronaService : Controller, ICaronaService
    {
        private IFachada _fachada;

        public CaronaService(IFachada fachada)
        {
            _fachada = fachada;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Carona carona)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _fachada.ListCaronas();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCarona")]
        public IActionResult Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CaronaUpdateDto colaborador)
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePartially(int id, [FromBody] JsonPatchDocument<Carona> patchDoc)
        {
            throw new NotImplementedException();
        }
    }
}
