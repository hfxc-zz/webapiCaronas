using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public abstract class AEntidadeBaseBloqueavel : AEntidadeBase, IBloqueavel
    {
        public bool Bloqueado { get; set; }

        public AEntidadeBaseBloqueavel() : base()
        {

        }

        public void Bloquear()
        {
            Bloqueado = true;
        }

        public void Desbloquear()
        {
            Bloqueado = false;
        }

        public bool EstaBloqueado()
        {
            return Bloqueado;
        }
    }
}
