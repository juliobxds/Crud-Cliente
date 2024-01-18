using Crud_Cliente.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Clientes.Negocio.Interfaces {
    public interface IService<T> where T : class { // todos herdeiros precisaram implementar os métodos!

        Task<List<T>> ListarTodos();

        Task<T> GetId(int id);

        Task<T> Adicionar(T obj);

        Task<T> Atualizar(T cliente);

        Task<T> Apagar(int id);
    }
}
