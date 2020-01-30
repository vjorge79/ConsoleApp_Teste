using System.Collections.Generic;
using System.Linq;
using ConsoleApp_TEste.Models;

namespace ConsoleApp_TEste.Services
{
    public class EstoqueStore : IDataStore<Estoque>
    {
        readonly List<Estoque> estoques;

        public EstoqueStore()
        {
            estoques = new List<Estoque>();
        }

        public IEnumerable<Estoque> Get()
        {
            return estoques;
        }

        public Estoque Get(int id)
        {
            return estoques.FirstOrDefault(s => s.Id == id);
        }

        public bool Add(Estoque item)
        {
            estoques.Add(item);

            return true;
        }

        public bool Update(Estoque item)
        {
            var oldItem = estoques.Where((Estoque arg) => arg.Id == item.Id).FirstOrDefault();
            estoques.Remove(oldItem);
            estoques.Add(item);

            return true;
        }

        public bool Delete(int id)
        {
            var oldItem = estoques.Where((Estoque arg) => arg.Id == id).FirstOrDefault();
            estoques.Remove(oldItem);

            return true;
        }
    }
}
