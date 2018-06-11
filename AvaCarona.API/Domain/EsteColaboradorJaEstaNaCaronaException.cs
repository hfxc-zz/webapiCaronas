using System;

namespace AvaCarona.API.Domain
{
    public class EsteColaboradorJaEstaNaCaronaException : Exception
    {
        private string _eid;

        public EsteColaboradorJaEstaNaCaronaException(string eid)
        {
            _eid = eid;
        }

        public override string Message => $"Já foi adicionado o colaborador (EID: {_eid}) a esta carona.";
    }
}