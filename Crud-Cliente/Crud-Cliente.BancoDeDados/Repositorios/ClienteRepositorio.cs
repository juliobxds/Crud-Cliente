using Crud_Cliente.BancoDeDados.Interfaces;
using Crud_Cliente.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Cliente.BancoDeDados.Repositorios {
    public class ClienteRepositorio : IRepositorio<Cliente> {

        private readonly Contexto contexto;

        public ClienteRepositorio(Contexto contexto) {
            this.contexto = contexto;
        }
        public async Task<Cliente> Adicionar(Cliente obj) {

            await contexto.AddAsync(obj);
            await contexto.SaveChangesAsync();

            return obj;
        }

        public async Task<Cliente> Atualizar(int id) {

          var Cliente = await contexto.Clientes.FirstOrDefaultAsync(c => c.Id == id); // fazer validaçoes!! 
            return Cliente;

        }
        public async Task<Cliente> Apagar(int id) {
            var Cliente = await contexto.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            contexto.Clientes.Remove(Cliente);
            return Cliente;
        }


        public async Task<Cliente> GetId(int id) {
            var Cliente = await contexto.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return Cliente;

        }

        public async Task<List<Cliente>> ListarTodos() {
          return await contexto.Clientes.ToListAsync();
        }
    }
}
