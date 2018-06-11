using AvaCarona.API.Domain;
using AvaCarona.WebAPI.ModelView;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.WebAPI.Services
{
    public interface IColaboradorService
    {
        IActionResult Get();

        IActionResult Get(int id);

        IActionResult Create(Colaborador colaborador);

        IActionResult Update(int id, ColaboradorUpdateDto colaborador);

        IActionResult UpdatePartially(int id, JsonPatchDocument<Colaborador> patchDoc);

        IActionResult Delete(int id);
    }
}
