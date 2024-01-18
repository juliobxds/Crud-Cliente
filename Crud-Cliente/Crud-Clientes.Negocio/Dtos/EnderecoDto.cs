using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Clientes.Negocio.Dtos {
    public class EnderecoDto {
        public int Id { get; set; }
        public string NomeDaRua { get; set; }
        public string NumeroDaRua { get; set; }
        public string Bairro { get; set; }
    }
}
