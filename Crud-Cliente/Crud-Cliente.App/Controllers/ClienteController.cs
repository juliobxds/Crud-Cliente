using Crud_Cliente.App.Models;
using Crud_Cliente.Entidades;
using Crud_Clientes.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crud_Cliente.App.Controllers {
    public class ClienteController : Controller {
        private readonly IService<Cliente> _service;
        private readonly IService<Endereco> _enderecoService;

        public ClienteController(IService<Cliente> service, IService<Endereco> enderecoService) {
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

        [HttpPost]
        public async Task<IActionResult> CadastroCliente(ClienteViewModel model) {
            var Endereco = new Endereco() { NomeDaRua = model.NomeDaRua, Bairro = model.Bairro, NumeroDaRua = model.NumeroDaRua};
           //var EnderecoAdd = await _enderecoService.Adicionar(Endereco);
            var Cliente = new Cliente() { Celular = model.Celular, Cpf = model.Cpf, Email = model.Email, Nome = model.Nome, Endereco = Endereco};
            await _service.Adicionar(Cliente);

            return View();
        }
    }
}
