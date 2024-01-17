using Crud_Cliente.BancoDeDados.Interfaces;
using Crud_Cliente.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Cliente.BancoDeDados.Repositorios {
    public class EnderecoRepositorio : IRepositorio<Endereco> {

        private readonly Contexto contexto;

        public EnderecoRepositorio(Contexto contexto) {
            this.contexto = contexto;
        }

        public async Task<Endereco> Adicionar(Endereco obj) {
            await contexto.AddAsync(obj);
            await contexto.SaveChangesAsync();
            return obj;

        }

        public async Task<Endereco> Apagar(int id) {
            var Endereco = await contexto.Endereco.FirstOrDefaultAsync(c => c.Id == id);
            contexto.Remove(Endereco);
            return Endereco;
        }

        public async Task<Endereco> Atualizar(int id) {
            var Endereco = await contexto.Endereco.FirstOrDefaultAsync(c => c.Id == id); // fazer validaçoes!! 
            return Endereco;
        }

        public async Task<Endereco> GetId(int id) {
            var Endereco = await contexto.Endereco.FirstOrDefaultAsync(c => c.Id == id);
            return Endereco;
        }

        public async Task<List<Endereco>> ListarTodos() {
            return await contexto.Endereco.ToListAsync();
        }
    }
}
