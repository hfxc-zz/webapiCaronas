using AvaCarona.API.Domain;
using AvaCarona.WebAPI.ModelView;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AvaCarona.WebAPI.Services
{
    public interface ICaronaService
    {
        IActionResult Get();

        IActionResult Get(int id);

        IActionResult Create(Carona carona);

        IActionResult Update(int id, CaronaUpdateDto colaborador);

        IActionResult UpdatePartially(int id, JsonPatchDocument<Carona> patchDoc);

        IActionResult Delete(int id);
    }
}
