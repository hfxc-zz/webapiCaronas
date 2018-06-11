using System;

namespace AvaCarona.API.Domain
{
    public class LimiteVagasExcedidoException : Exception
    {
        private int _vagas;

        public LimiteVagasExcedidoException(int vagas)
        {
            _vagas = vagas;
        }

        public override string Message => $"Só é permitido carros com até {_vagas}.";
    }
}