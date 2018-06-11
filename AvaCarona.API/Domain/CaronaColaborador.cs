using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class CaronaColaborador
    {
        public int CaronaId { get; set; }

        public int ColaboradorId { get; set; }

        public Carona Carona { get; set; }

        public Colaborador Colaborador { get; set; }
    }
}
