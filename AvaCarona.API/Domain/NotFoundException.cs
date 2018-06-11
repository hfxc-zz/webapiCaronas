using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public override string Message => "Não encontrou o item.";
    }
}
