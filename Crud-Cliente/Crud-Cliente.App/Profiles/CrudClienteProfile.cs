using AutoMapper;
using Crud_Cliente.App.Dtos;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Dtos;

namespace Crud_Cliente.App.Profiles {
    public class CrudClienteProfile : Profile {
        
        public CrudClienteProfile() {

            CreateMap<Cliente, ClienteDto>();
            CreateMap<Endereco, EnderecoDto>();

        }

    }
}
