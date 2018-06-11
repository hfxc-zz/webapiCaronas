using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositories
{
    public class CaronaRepositoryEF : ARepositoryEF<Carona>, ICaronaRepository
    {
        public CaronaRepositoryEF(CaronaAppContext context) : base(context)
        {
        }
    }
}
