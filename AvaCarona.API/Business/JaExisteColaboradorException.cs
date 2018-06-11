using AvaCarona.API.Domain;
using System;

namespace AvaCarona.API.Business
{
    public class JaExisteColaboradorException : Exception
    {
        private Colaborador _colaborador;

        public JaExisteColaboradorException()
        {
        }

        public JaExisteColaboradorException(Colaborador colaborador)
        {
            _colaborador = colaborador;
        }

        public override string Message => $"O colaborador ({_colaborador}) já existe.";
    }
}