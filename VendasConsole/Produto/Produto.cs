using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VendasConsole.Program;

namespace VendasConsole {
    class Produto {

        public int Id { get; set; }
        public string Nome { get; set; }

        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataCadastro { get; set; }

        public Produto(int id, string nome, double preco, int quantidade) {

            if (!IsNomeNovo(nome)) {
                throw new Exception("Já existe um produto com esse nome!");
            }

            Id = id;
            Nome = nome.Trim();
            Preco = preco;
            Quantidade = quantidade;
            DataCadastro = DateTime.Now;
        }

        public Produto(string nome, int quantidade) {
            Nome = nome;
            Quantidade = quantidade;
        }
        public bool IsNomeNovo(String nome) {
            return !Produtos.Any<Produto>(p => p.Nome.Equals(nome.Trim()));
        }

        public override string ToString() {
            return $"ID: {Id}\n" +
                   $"NOME: {Nome}\n" +
                   $"PREÇO: {Preco}\n" +
                   $"QUANTIDADE:`{Quantidade}\n" +
                   $"DATA DE CADASTRO: {DataCadastro}\n\n"; ;
        }


    }
}
