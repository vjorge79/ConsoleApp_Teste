using ConsoleApp_TEste.Models;
using ConsoleApp_TEste.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_TEste
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtos = new ProdutoStore();
            produtos.Add(new Produto() { Id = 1, Nome = "Mouse" });
            produtos.Add(new Produto() { Id = 2, Nome = "Caneta" });
            produtos.Add(new Produto() { Id = 3, Nome = "Caderno" });

            var produtoMouse = produtos.Get(1);
            var produtoCaneta = produtos.Get(2);
            var produtoCaderno = produtos.Get(3);

            //  Estoque fisico
            //
            //  Produto     Endereço    Quantidade
            //  MOUSE       A-01        2
            //  MOUSE       A-02        1
            //  CADERNO     J-17        2
            //  CANETA      H-20        3
            var estoques = new EstoqueStore();
            estoques.Add(new Estoque() { Id = 1, Produto = produtoMouse, EnderecoFisico = "A-01", QuantidadeFisica = 2 });
            estoques.Add(new Estoque() { Id = 2, Produto = produtoMouse, EnderecoFisico = "A-02", QuantidadeFisica = 1 });
            estoques.Add(new Estoque() { Id = 3, Produto = produtoCaderno, EnderecoFisico = "J-17", QuantidadeFisica = 2 });
            estoques.Add(new Estoque() { Id = 4, Produto = produtoCaneta, EnderecoFisico = "H-20", QuantidadeFisica = 3 });

            var pedidoItens = new PedidoItemStore();
            pedidoItens.Add(new PedidoItem() { Id = 1, Produto = produtoMouse, QuantidadeSolicitada = 1, QuantidadeAtendida = 0 });
            pedidoItens.Add(new PedidoItem() { Id = 2, Produto = produtoCaneta, QuantidadeSolicitada = 10, QuantidadeAtendida = 0 });
            pedidoItens.Add(new PedidoItem() { Id = 3, Produto = produtoMouse, QuantidadeSolicitada = 2, QuantidadeAtendida = 0 });
            pedidoItens.Add(new PedidoItem() { Id = 4, Produto = produtoCaneta, QuantidadeSolicitada = 3, QuantidadeAtendida = 0 });
            pedidoItens.Add(new PedidoItem() { Id = 5, Produto = produtoCaderno, QuantidadeSolicitada = 2, QuantidadeAtendida = 0 });

            var pedidoItens1 = new List<PedidoItem>
            {
                pedidoItens.Get(1),
                pedidoItens.Get(2),
            };
            var pedidoItens2 = new List<PedidoItem>
            {
                pedidoItens.Get(3),
                pedidoItens.Get(4),
                pedidoItens.Get(5),
            };

            ////  Pedidos
            ////
            ////  Pedido 1 Cliente Sadao
            ////      Produto     Quantidade solicitada     qtde atendida
            ////      MOUSE       1                           
            ////      CANETA      10                           
            ////
            ////  Pedido 2 Cliente João
            ////      Produto     Quantidade solicitada
            ////      MOUSE       2
            ////      CANETA      3
            ////      CADERNO     2

            var pedidos = new PedidoStore();
            pedidos.Add(new Pedido() { Id = 1, Cliente = "Sadao", Itens = pedidoItens1 });
            pedidos.Add(new Pedido() { Id = 2, Cliente = "Joao", Itens = pedidoItens2 });

            Console.WriteLine("Estoque");
            foreach (var estoque in estoques.Get())
            {
                Console.WriteLine($"Id: {estoque.Id}, Produto: {estoque.Produto.Nome}, Endereco Fisico: {estoque.EnderecoFisico}, Quantidade Fisica: {estoque.QuantidadeFisica}");
            }

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("Pedido");
            foreach (var pedido in pedidos.Get())
            {
                Console.WriteLine($"IdPedido: {pedido.Id}, Cliente: {pedido.Cliente}");
                foreach (var item in pedido.Itens)
                {
                    Console.WriteLine($"IdPedidoItem: {item.Id}, Cliente: {item.Produto.Nome}, Quantidade Solicitada: {item.QuantidadeSolicitada}, Quantidade Atendida : {item.QuantidadeAtendida}");
                }
                Console.WriteLine();
            }

            foreach (var pedido in pedidos.Get())
            {
                foreach (var pedidoItem in pedido.Itens)
                {
                    // Quantidade em estoque do produto
                    // TODO: Criar interface de produto e implementar metodo que retorna a qtde em estoque do produto
                    var quantidadeFisica = 0;
                    var estoquesItem = estoques.Get().Where(p => p.Produto.Id.Equals(pedidoItem.Produto.Id));

                    foreach (var estoque in estoquesItem)
                    {
                        quantidadeFisica += estoque.QuantidadeFisica;
                    }

                    // Quantidade atendida por produto
                    // TODO: Criar interface de produto e implementar metodo que retorna a qtde em atendida do produto
                    var quantidadeAtendida = 0;
                    var pedidoItemAtendido = pedidoItens.Get().Where(p => p.Produto.Id.Equals(pedidoItem.Produto.Id));
                    foreach (var item in pedidoItemAtendido)
                    {
                        quantidadeAtendida += item.QuantidadeAtendida;
                    }
                    
                    if (pedidoItem.QuantidadeSolicitada <= quantidadeFisica-quantidadeAtendida)
                    {
                        pedidoItem.QuantidadeAtendida = pedidoItem.QuantidadeSolicitada;
                        pedidoItens.Update(pedidoItem);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Pedido");
            foreach (var pedido in pedidos.Get())
            {
                Console.WriteLine($"IdPedido: {pedido.Id}, Cliente: {pedido.Cliente}");
                foreach (var item in pedido.Itens)
                {
                    Console.WriteLine($"IdPedidoItem: {item.Id}, Cliente: {item.Produto.Nome}, Quantidade Solicitada: {item.QuantidadeSolicitada}, Quantidade Atendida : {item.QuantidadeAtendida}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
