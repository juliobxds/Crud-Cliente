using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Cliente.BancoDeDados.Interfaces {
    public interface IRepositorio<T> where T : class { // (repositorio generico)  todos herdeiros precisaram implementar os métodos!

        Task<List<T>> ListarTodos();

        Task<T> GetId(int id);

        Task<T> Adicionar(T obj);

        Task<T> Atualizar(int id);

        Task<T> Apagar(int id); 
    }
}
