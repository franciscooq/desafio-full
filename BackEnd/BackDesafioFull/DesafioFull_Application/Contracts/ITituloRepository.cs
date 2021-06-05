using DesafioFull_Application.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFull_Application.Contracts
{
    public interface ITituloRepository
    {
        Task<Titulo> ObterPorId(int id);
        Task<IEnumerable<Titulo>> ObterTodos();
        void NovoTitulo(Titulo request);
    }
}
