using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_TEste.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public int QuantidadeAtendida { get; set; }
    }
}
