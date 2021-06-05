using DesafioFull_Application.Contracts;
using DesafioFull_Application.Dtos;
using DesafioFull_Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFull_Business.Business
{
    public class TituloBusiness : ITituloBusiness
    {
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
                var titulo = await _tituloRepository.ObterPorId(id);

                titulo.Parcelas = AtualizaParcelasEmAtraso(titulo.Parcelas);

                return TituloToTituloResponsetMap(titulo);
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
                var titulos = await _tituloRepository.ObterTodos();

                foreach (var titulo in titulos)
                {
                    titulo.Parcelas = AtualizaParcelasEmAtraso(titulo.Parcelas);
                }

                return TituloToTituloResponsetListMap(titulos);
            }
            catch (Exception)
            {
                throw new Exception($"Falha ao recuperar a lista de Títulos.");
            }
        }

        private List<Parcela> AtualizaParcelasEmAtraso(List<Parcela> parcelas)
        {
            DateTime today = DateTime.Today;



            return parcelas;
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
