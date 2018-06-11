using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AvaCarona.API.Business;
using AvaCarona.API.Domain;
using AvaCarona.WebAPI.ModelView;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AvaCarona.WebAPI.Services
{
    [Route("api/colaborador")]
    public class ColaboradorService : Controller, IColaboradorService
    {
        private IFachada _fachada;

        public ColaboradorService(IFachada fachada)
        {
            _fachada = fachada;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Colaborador colaborador)
        {
            try
            {
                Colaborador createdColaboradorToReturn = _fachada.CadastrarColaborador(colaborador);

                return CreatedAtRoute("GetColaborador", new { id = createdColaboradorToReturn.Id }, createdColaboradorToReturn);
            }
            catch (JaExisteColaboradorException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _fachada.RemoverColaborador(id);

            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _fachada.ListColaboradores();
            Console.Write(result);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetColaborador")]
        public IActionResult Get(int id)
        {
            var result = _fachada.GetColaboradorById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ColaboradorUpdateDto colaboradorDto)
        {
            if (colaboradorDto == null) return BadRequest();

            var colaboradorEntity = _fachada.GetColaboradorById(id);
            if (colaboradorEntity != null)
            {
                colaboradorEntity = Mapper.Map<Colaborador>(colaboradorDto);
                _fachada.UpdateColaborador(colaboradorEntity);

                return NoContent();
            }

            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePartially(int id, [FromBody] JsonPatchDocument<Colaborador> patchDoc)
        {
            if (patchDoc == null) return BadRequest();

            var colaboradorEntity = _fachada.GetColaboradorById(id);
            if (colaboradorEntity == null) throw new NotFoundException();

            patchDoc.ApplyTo(colaboradorEntity, ModelState);

            try
            {
                _fachada.UpdateColaborador(colaboradorEntity);
            }
            catch (JaExisteColaboradorException e)
            {
                return StatusCode(500, e.Message);
            }


            return NoContent();
        }
    }
}
