using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class CaronaJaEstaVaziaException : Exception
    {
        public override string Message => "Esta carona já está vazia.";
    }
}
