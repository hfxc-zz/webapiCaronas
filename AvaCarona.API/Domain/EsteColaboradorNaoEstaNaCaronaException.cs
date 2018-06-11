using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Domain
{
    public class EsteColaboradorNaoEstaNaCaronaException : Exception
    {
        private string _eid;

        public EsteColaboradorNaoEstaNaCaronaException(string eid)
        {
            _eid = eid;
        }

        public override string Message => $"O colaborador (EID: {_eid}) não está nesta carona.";
    }
}
