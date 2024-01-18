using Crud_Cliente.App.Models;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crud_Cliente.App.Dtos;
using Crud_Clientes.Negocio.Dtos;

namespace Crud_Cliente.App.Controllers {
    public class ClienteController : Controller {
        private readonly IService<ClienteDto> _service;
        private readonly IService<EnderecoDto> _enderecoService;
        public ClienteController(IService<ClienteDto> service, IService<EnderecoDto> enderecoService) {
            _service = service;
            _enderecoService = enderecoService;
        }

        public IActionResult Index() {
            return View();
        }
        [HttpGet]
        public IActionResult CadastroCliente() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarCliente() {
            var clientes = await _service.ListarTodos();
            var lista = new List<ClienteViewModel>();
            foreach (var cliente in clientes) {
                var clienteViewModel = new ClienteViewModel {Id = cliente.Id, Nome = cliente.Nome, Celular = cliente.Celular, Cpf = cliente.Cpf,
                    Email = cliente.Email, NomeDaRua = cliente.Endereco.NomeDaRua, NumeroDaRua = cliente.Endereco.NumeroDaRua, Bairro = cliente.Endereco.Bairro,
                };
                lista.Add(clienteViewModel);

            var clienteR = new List<ClienteDto>();
                foreach (var Cliente in clientes) {
                    clienteR.Add(new ClienteDto {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        Celular = cliente.Celular,
                        Cpf = cliente.Cpf,
                        Email = cliente.Email,
                        NomeDaRua = cliente.NomeDaRua,
                        NumeroDaRua = cliente.NumeroDaRua,
                        Bairro = cliente.Bairro,
                    });
                }
            }
            return View(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CadastroCliente(ClienteViewModel model) {
            var Endereco = new EnderecoDto() { NomeDaRua = model.NomeDaRua, Bairro = model.Bairro, NumeroDaRua = model.NumeroDaRua };
            var EnderecoAdd = await _enderecoService.Adicionar(Endereco);
            var Cliente = new ClienteDto() { Celular = model.Celular, Cpf = model.Cpf, Email = model.Email, Nome = model.Nome, EnderecoId = EnderecoAdd.Id };
            await _service.Adicionar(Cliente);

            return View();
        }

        [HttpGet] // RESPONSAVEL POR ABRIR A PAGINA! 
        public async Task<IActionResult> EditarCliente(int id) {
            var cliente = await _service.GetId(id);
            var model = new ClienteViewModel() {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Celular = cliente.Celular,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
                NomeDaRua = cliente.Endereco.NomeDaRua,
                NumeroDaRua = cliente.Endereco.NumeroDaRua,
                Bairro = cliente.Endereco.Bairro,
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> EditarCliente(ClienteViewModel model) {
            var Endereco = new Endereco() { NomeDaRua = model.NomeDaRua, Bairro = model.Bairro, NumeroDaRua = model.NumeroDaRua, Id = model.Id, };
            var Cliente = new ClienteDto() { Id = model.Id, Celular = model.Celular, Cpf = model.Cpf, Email = model.Email, Nome = model.Nome };
            var cliente = await _service.Atualizar(Cliente);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> ApagarCliente(int id) {
            var cliente = await _service.Apagar(id);
            return View(id);

        }
    }
}

