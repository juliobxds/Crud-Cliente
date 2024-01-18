using AutoMapper;
using Crud_Cliente.App.Dtos;
using Crud_Cliente.BancoDeDados.Interfaces;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Dtos;
using Crud_Clientes.Negocio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Clientes.Negocio.Service {
    public class EnderecoServico : IService<EnderecoDto> {
        private readonly IRepositorio<Endereco> enderecoRepositorio;
        private readonly IMapper mapper;
        public EnderecoServico(IRepositorio<Endereco> enderecoRepositorio, IMapper mapper) {
            this.enderecoRepositorio = enderecoRepositorio;
            this.mapper = mapper;
        }
        public async Task<EnderecoDto> Adicionar(EnderecoDto obj) {
            var map = mapper.Map<Endereco>(obj);
            var endereco = await enderecoRepositorio.Adicionar(map);
            var map3 = mapper.Map<EnderecoDto>(endereco);
            return map3;
        }
        public async Task<EnderecoDto> Apagar(int id) {
           var endereco = await enderecoRepositorio.Apagar(id);
            var dto = mapper.Map<EnderecoDto>(endereco);
            return dto;
        }
        public async Task<EnderecoDto> Atualizar(EnderecoDto endereco) {
            var map = mapper.Map<Endereco>(endereco);
            var enderecos = await enderecoRepositorio.Atualizar(map);
            var map3 = mapper.Map<EnderecoDto>(enderecos);
            return map3;
        }
        public async Task<EnderecoDto> GetId(int id) {
            var endereco = await enderecoRepositorio.GetId(id);
            var map2 = mapper.Map<EnderecoDto>(endereco);
            return map2;
        }
        public async Task<List<EnderecoDto>> ListarTodos() {
            var endereco = await enderecoRepositorio.ListarTodos();
            var map = mapper.Map<List<EnderecoDto>>(endereco);
            return map;

        }
    }
}
