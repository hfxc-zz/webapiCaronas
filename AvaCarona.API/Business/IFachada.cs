using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Business
{
    public interface IFachada
    {
        Colaborador GetColaboradorById(int id);
        IList<Colaborador> ListColaboradores();
        Colaborador CadastrarColaborador(Colaborador colaborador);
        int RemoverColaborador(int id);
        void UpdateColaborador(Colaborador colaborador);

        Carona GetCaronaById(int id);
        IList<Carona> ListCaronas();
        Carona CadastrarCarona(Carona carona);
        int RemoverCarona(int id);
    }
}
