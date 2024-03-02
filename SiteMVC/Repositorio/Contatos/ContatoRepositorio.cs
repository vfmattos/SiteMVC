using SiteMVC.Data;
using SiteMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiteMVC.Repositorio.Contatos
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext banco)
        {
            _bancoContext = banco;
        }

        //Original retorna ContatoModel ao invés de void
        public void Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

        }

        public void ApagarContato(int id)
        {
            var contato = ListarPorID(id);
            _bancoContext.Contatos.Remove(contato);
            _bancoContext.SaveChanges();
        }

        public void AtualizarContato(ContatoModel contato)
        {

            if (contato == null) { throw new System.ArgumentNullException(string.Empty); }

            var contatoAlterado = ListarPorID(contato.Id);

            contatoAlterado.Nome = contato.Nome;
            contatoAlterado.Email = contato.Email;
            contatoAlterado.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoAlterado);
            _bancoContext.SaveChanges();


        }

        public List<ContatoModel> Listar()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarPorID(int id)
        {
            var contato = Listar().FirstOrDefault(x => x.Id == id);

            return contato;
        }
    }
}
