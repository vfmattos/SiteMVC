using SiteMVC.Models;
using System.Collections.Generic;

namespace SiteMVC.Repositorio.Contatos
{
    public interface IContatoRepositorio
    {

        public ContatoModel ListarPorID(int id);
        public void AtualizarContato(ContatoModel contato);
        public void ApagarContato(int id);
        public List<ContatoModel> Listar();

        //Original retorna ContatoModel ao invés de void
        public void Adicionar(ContatoModel contato);
    }
}
