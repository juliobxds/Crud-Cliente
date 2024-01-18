using AutoMapper;
using Crud_Cliente.App.Dtos;
using Crud_Cliente.BancoDeDados.Interfaces;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Crud_Clientes.Negocio.Service {
    public class ClienteServico : IService<ClienteDto> {
        private readonly IRepositorio<Cliente> clientesRepositorio;
        private readonly IMapper mapper;

        public ClienteServico(IRepositorio<Cliente> clientesRepositorio, IMapper mapper) {
            this.clientesRepositorio = clientesRepositorio;
            this.mapper = mapper;
        }
        public async Task<ClienteDto> Adicionar(ClienteDto obj) {
            var map = mapper.Map<Cliente>(obj);
            var cliente = await clientesRepositorio.Adicionar(map);
            var remap = mapper.Map<ClienteDto>(cliente);
            return remap;
        }
        public async Task<ClienteDto> Apagar(int id) {
            var cliente = await clientesRepositorio.Apagar(id);
            var remap = mapper.Map<ClienteDto>(cliente);
            return remap;
        }

        public async Task<ClienteDto> Atualizar(ClienteDto cliente) {
            var map1 = mapper.Map<Cliente>(cliente);
            var clienter = await clientesRepositorio.Atualizar(map1);
            var remap = mapper.Map<ClienteDto>(clienter);
            return remap;
        }

        public async Task<ClienteDto> GetId(int id) {
            var cliente = await clientesRepositorio.GetId(id);
            var remap = mapper.Map<ClienteDto>(cliente);
            return remap;
        }

        public async Task<List<ClienteDto>> ListarTodos() {
            var cliente = await clientesRepositorio.ListarTodos();
            var map = mapper.Map<List<ClienteDto>>(cliente);
            return map;
        }
    }
}
