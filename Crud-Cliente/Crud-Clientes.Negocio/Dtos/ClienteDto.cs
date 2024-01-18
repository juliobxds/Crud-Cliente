﻿using Crud_Cliente.Entidades;

namespace Crud_Cliente.App.Dtos {
    public class ClienteDto {

        public int Id { get; set; }
        public string Nome { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string NomeDaRua { get; set; }
        public string NumeroDaRua { get; set; }
        public string Bairro { get; set; }

        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }
    }
}
