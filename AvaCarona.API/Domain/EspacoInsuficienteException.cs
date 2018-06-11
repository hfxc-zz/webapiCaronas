using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class EspacoInsuficienteException : Exception
    {
        public override string Message => "Não há espaço suficiente na carona";
    }
}
