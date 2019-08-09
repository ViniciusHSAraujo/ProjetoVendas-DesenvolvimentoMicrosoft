using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasConsole {
    class Venda {

        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        public Vendedor Vendedor { get; set; }

        public List<Produto> Produtos { get; set; }

        public DateTime DataVenda { get; set; }


        public Venda(int id, Cliente cliente, Vendedor vendedor, List<Produto> produtos) {
            Id = id;
            Cliente = cliente;
            Vendedor = vendedor;
            Produtos = produtos;
            DataVenda = DateTime.Now;
        }

        public override string ToString() {

            string produtosString = "";

            Produtos.ForEach(p => { produtosString += $"{p.Nome} - {p.Quantidade}\n"; });

            return $"ID: {Id}\n" +
                   $"CLIENTE: {Cliente.Nome}\n" +
                   $"VENDEDOR: {Vendedor.Nome}\n" +
                   $"DATA DA VENDA: {DataVenda.ToLocalTime()}\n" +
                   $"PRODUTOS/QUANTIDADES:\n" +
                   $"{produtosString}"; 
        }

    }
}
