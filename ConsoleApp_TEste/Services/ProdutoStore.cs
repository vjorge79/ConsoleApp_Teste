using System.Collections.Generic;
using System.Linq;
using ConsoleApp_TEste.Models;

namespace ConsoleApp_TEste.Services
{
    public class ProdutoStore : IDataStore<Produto>
    {
        readonly List<Produto> produtos;

        public ProdutoStore()
        {
            produtos = new List<Produto>();
        }

        public IEnumerable<Produto> Get()
        {
            return produtos;
        }

        public Produto Get(int id)
        {
            return produtos.FirstOrDefault(s => s.Id == id);
        }

        public bool Add(Produto produto)
        {
            produtos.Add(produto);

            return true;
        }

        public bool Update(Produto produto)
        {
            var oldItem = produtos.Where((Produto arg) => arg.Id == produto.Id).FirstOrDefault();
            produtos.Remove(oldItem);
            produtos.Add(produto);

            return true;
        }

        public bool Delete(int id)
        {
            var oldItem = produtos.Where((Produto arg) => arg.Id == id).FirstOrDefault();
            produtos.Remove(oldItem);

            return true;
        }
    }
}
