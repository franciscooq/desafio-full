using DesafioFull_Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFull_Application.Contracts
{
    public interface ITituloBusiness
    {
        Task<TituloResponse> ObterPorId(int id);
        Task<IEnumerable<TituloResponse>> ObterTodos();
        void NovoTitulo(TituloRequest request);
    }
}
