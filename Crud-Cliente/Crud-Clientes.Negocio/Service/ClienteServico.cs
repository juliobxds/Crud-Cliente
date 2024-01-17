using Crud_Cliente.BancoDeDados.Interfaces;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Clientes.Negocio.Service {
    public class ClienteServico : IService<Cliente> {
        private readonly IRepositorio<Cliente> clientesRepositorio;

        public ClienteServico(IRepositorio<Cliente> clientesRepositorio) {
            this.clientesRepositorio = clientesRepositorio;
        }
        public async Task<Cliente> Adicionar(Cliente obj) {
         return await clientesRepositorio.Adicionar(obj);
        }

        public async Task<Cliente> Apagar(int id) {
            return await clientesRepositorio.Apagar(id);
        }

        public async Task<Cliente> Atualizar(int id) {
           return await clientesRepositorio.Atualizar(id);
        }

        public async Task<Cliente> GetId(int id) {
            return await clientesRepositorio.GetId(id);
        }
           
        public async Task<List<Cliente>> ListarTodos() {
            return await clientesRepositorio.ListarTodos();
        }
    }
}
