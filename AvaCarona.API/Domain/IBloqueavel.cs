using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public interface IBloqueavel
    {
        void Bloquear();

        void Desbloquear();

        bool EstaBloqueado();
    }
}
