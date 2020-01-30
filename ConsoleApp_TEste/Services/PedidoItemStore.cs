using System.Collections.Generic;
using System.Linq;
using ConsoleApp_TEste.Models;

namespace ConsoleApp_TEste.Services
{
    public class PedidoItemStore : IDataStore<PedidoItem>
    {
        readonly List<PedidoItem> pedidoItens;

        public PedidoItemStore()
        {
            pedidoItens = new List<PedidoItem>();
        }

        public IEnumerable<PedidoItem> Get()
        {
            return pedidoItens;
        }

        public PedidoItem Get(int id)
        {
            return pedidoItens.FirstOrDefault(s => s.Id == id);
        }

        public bool Add(PedidoItem pedidoItem)
        {
            pedidoItens.Add(pedidoItem);

            return true;
        }

        public bool Update(PedidoItem pedidoItem)
        {
            var oldItem = pedidoItens.Where((PedidoItem arg) => arg.Id == pedidoItem.Id).FirstOrDefault();
            pedidoItens.Remove(oldItem);
            pedidoItens.Add(pedidoItem);

            return true;
        }

        public bool Delete(int id)
        {
            var oldItem = pedidoItens.Where((PedidoItem arg) => arg.Id == id).FirstOrDefault();
            pedidoItens.Remove(oldItem);

            return true;
        }
    }
}
