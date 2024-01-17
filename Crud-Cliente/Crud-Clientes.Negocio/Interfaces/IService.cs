using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Clientes.Negocio.Interfaces {
    public interface IService<T> where T : class { // todos herdeiros precisaram implementar os métodos!

        Task<List<T>> ListarTodos();

        Task<T> GetId(int id);

        Task<T> Adicionar(T obj);

        Task<T> Atualizar(int id);

        Task<T> Apagar(int id);
    }
}
