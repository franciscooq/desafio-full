using DesafioFull_Application.Entities;
using System.Collections.Generic;

namespace DesafioFull_Application.Dtos
{
    public class TituloRequest
    {
        public string NumeroTitulo { get; set; }
        public Cliente ClienteDevedor { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public List<Parcela> Parcelas { get; set; }
    }
}
