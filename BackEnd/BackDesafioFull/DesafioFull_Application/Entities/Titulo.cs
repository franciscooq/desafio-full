using System.Collections.Generic;

namespace DesafioFull_Application.Entities
{
    public class Titulo
    {
        public int id { get; set; }
        public string NumeroTitulo { get; set; }
        public Cliente ClienteDevedor { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public List<Parcela> Parcelas { get; set; }
    }
}