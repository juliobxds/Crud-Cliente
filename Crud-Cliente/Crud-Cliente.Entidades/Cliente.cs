namespace Crud_Cliente.Entidades {
    public class Cliente {

        public int Id { get; set; }
        public string Nome { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }
    }
}
