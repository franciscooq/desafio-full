using DesafioFull_Application.Contracts;
using DesafioFull_Application.Dtos;
using DesafioFull_Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DesafioFull_Business.Business
{
    public class TituloBusiness : ITituloBusiness
    {
        DateTime TODAY = DateTime.Today;

        private readonly ITituloRepository _tituloRepository;

        public TituloBusiness(ITituloRepository tituloRepository)
        {
            _tituloRepository = tituloRepository;
        }

        public void NovoTitulo(TituloRequest request)
        {
            try
            {
                var titulo = TituloRequestToTituloMap(request);

                _tituloRepository.NovoTitulo(titulo);
            }
            catch (Exception)
            {
                throw new Exception($"Ocorreu um erro inesperado ao incluir o Título do Cliente {request.ClienteDevedor.Nome}.");
            }
        }

        public async Task<TituloResponse> ObterPorId(int id)
        {
            try
            {
                var response = await _tituloRepository.ObterPorId(id);
                var titulo = TituloToTituloResponsetMap(response);

                titulo = AtualizaTitulo(titulo);

                return titulo;
            }
            catch (Exception)
            {
                throw new Exception($"Falha ao recuperar o Título de numero: {id}.");
            }
        }

        public async Task<IEnumerable<TituloResponse>> ObterTodos()
        {
            try
            {
                var response = await _tituloRepository.ObterTodos();
                var titulos = TituloToTituloResponsetListMap(response);

                foreach (var titulo in titulos)
                {
                    AtualizaTitulo(titulo);
                }

                return titulos;
            }
            catch (Exception)
            {
                throw new Exception($"Falha ao recuperar a lista de Títulos.");
            }
        }

        private TituloResponse AtualizaTitulo(TituloResponse titulo)
        {
            titulo.ValorOriginal = CalculaValorParcelas(titulo.Parcelas);
            titulo.DiasAtraso = ((int)((titulo.Parcelas.OrderBy(x => x.NumeroParcela).FirstOrDefault().DataVencimento) - TODAY).TotalDays) * -1;

            var multaCorrigida = titulo.ValorOriginal * titulo.Multa;
            var juros = (titulo.Juros / 100) * 30;
            var valorJuros = ObterValorJuros(titulo.Parcelas, juros);

            titulo.ValorAtualizado = titulo.ValorOriginal + multaCorrigida + valorJuros;

            return titulo;
        }

        private decimal CalculaValorParcelas(List<Parcela> parcelas)
        {
            return parcelas.Select(x => x.ValorParcela).Sum();
        }

        private decimal ObterValorJuros(List<Parcela> parcelas, decimal juros)
        {
            decimal valorJuros = 0;

            foreach (var parcela in parcelas)
            {
                var diasAtraso = ((decimal)(parcela.DataVencimento - TODAY).TotalDays) * -1;
                valorJuros += juros * diasAtraso * parcela.ValorParcela;
            }

            return valorJuros;
        }

        private Titulo TituloRequestToTituloMap(TituloRequest request)
        {
            return new Titulo()
            {
                NumeroTitulo = request.NumeroTitulo,
                ClienteDevedor = request.ClienteDevedor,
                Juros = request.Juros,
                Multa = request.Multa,
                Parcelas = request.Parcelas
            };
        }

        private TituloResponse TituloToTituloResponsetMap(Titulo response)
        {
            return new TituloResponse()
            {
                id = response.id,
                NumeroTitulo = response.NumeroTitulo,
                ClienteDevedor = response.ClienteDevedor,
                Juros = response.Juros,
                Multa = response.Multa,
                Parcelas = response.Parcelas
            };
        }

        private IEnumerable<TituloResponse> TituloToTituloResponsetListMap(IEnumerable<Titulo> titulos)
        {
            try
            {
                var responseList = new List<TituloResponse>();

                foreach (var titulo in titulos)
                {
                    responseList.Add(TituloToTituloResponsetMap(titulo));
                }

                return responseList;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
