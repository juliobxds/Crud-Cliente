using Crud_Cliente.BancoDeDados.Interfaces;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Clientes.Negocio.Service {
    public class EnderecoServico : IService<Endereco> {
        private readonly IRepositorio<Endereco> enderecoRepositorio;
        public EnderecoServico(IRepositorio<Endereco> enderecoRepositorio) {
            this.enderecoRepositorio = enderecoRepositorio;
        }
        public async Task<Endereco> Adicionar(Endereco obj) {
            return await enderecoRepositorio.Adicionar(obj);
        }

        public async Task<Endereco> Apagar(int id) {
            return await enderecoRepositorio.Apagar(id);
        }

        public async Task<Endereco> Atualizar(int id) {
            return await enderecoRepositorio.Atualizar(id);
        }

        public async Task<Endereco> GetId(int id) {
            return await enderecoRepositorio.GetId(id);
        }

        public async Task<List<Endereco>> ListarTodos() {
            return await enderecoRepositorio.ListarTodos();
        }
    }
}
