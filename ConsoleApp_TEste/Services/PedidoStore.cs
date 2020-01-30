using System.Collections.Generic;
using System.Linq;
using ConsoleApp_TEste.Models;

namespace ConsoleApp_TEste.Services
{
    public class PedidoStore : IDataStore<Pedido>
    {
        readonly List<Pedido> pedidos;

        public PedidoStore()
        {
            pedidos = new List<Pedido>();
        }

        public IEnumerable<Pedido> Get()
        {
            return pedidos;
        }

        public Pedido Get(int id)
        {
            return pedidos.FirstOrDefault(s => s.Id == id);
        }

        public bool Add(Pedido pedido)
        {
            pedidos.Add(pedido);

            return true;
        }

        public bool Update(Pedido pedido)
        {
            var oldItem = pedidos.Where((Pedido arg) => arg.Id == pedido.Id).FirstOrDefault();
            pedidos.Remove(oldItem);
            pedidos.Add(pedido);

            return true;
        }

        public bool Delete(int id)
        {
            var oldItem = pedidos.Where((Pedido arg) => arg.Id == id).FirstOrDefault();
            pedidos.Remove(oldItem);

            return true;
        }
    }
}
