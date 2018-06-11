using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositories
{
    public class ColaboradorRepositoryEF : ARepositoryEF<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepositoryEF(CaronaAppContext context) : base(context)
        {

        }
    }
}
