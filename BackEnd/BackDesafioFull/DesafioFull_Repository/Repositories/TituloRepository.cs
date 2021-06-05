using DesafioFull_Application.Contracts;
using DesafioFull_Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFull_Repository.Repositories
{
    public class TituloRepository : ITituloRepository
    {
        private List<Titulo> Titulos = new List<Titulo>();

        public TituloRepository()
        {
            Titulos.Add(
                        new Titulo()
                        {
                            id = 1,
                            NumeroTitulo = "33256",
                            Multa = 0.2m,
                            Juros = 0.1m,
                            ClienteDevedor = new Cliente()
                            {
                                CPF = "12345789854",
                                Nome = "Eric Macedo"
                            },
                            Parcelas = new List<Parcela>()
                            {
                                new Parcela()
                                {
                                    NumeroParcela = 1,
                                    DataVencimento = new DateTime(2021,1,15),
                                    ValorParcela = 37.50m
                                },
                                new Parcela()
                                {
                                    NumeroParcela = 2,
                                    DataVencimento = new DateTime(2021,2,15),
                                    ValorParcela = 37.50m
                                },
                                new Parcela()
                                {
                                    NumeroParcela = 2,
                                    DataVencimento = new DateTime(2021,3,15),
                                    ValorParcela = 38
                                },
                            }
                        }
            );
        }

        public void NovoTitulo(Titulo request)
        {
            int novoId = Titulos.OrderByDescending(x => x.id).First().id + 1;
            request.id = novoId;

            Titulos.Add(request);
        }

        public async Task<Titulo> ObterPorId(int id)
        {
            var result = Titulos.Where(x => x.id == id).FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<Titulo>> ObterTodos()
        {
            var result = Titulos.Select(x => x);

            return result.ToList();
        }
    }
}
