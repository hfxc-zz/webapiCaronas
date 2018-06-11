using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;

namespace AvaCarona.WebAPI.ModelView
{
    public class CaronaUpdateDto
    {
        public Colaborador Ofertante { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public Endereco EnderecoSaida { get; set; }
        public Endereco EnderecoChegada { get; set; }
        public int VagasTotais { get; set; }
        public int VagasDisponiveis
        {
            get
            {
                return VagasTotais - Caroneiros.Count;
            }
        }
        public ICollection<CaronaColaborador> Caroneiros { get; set; }
    }
}