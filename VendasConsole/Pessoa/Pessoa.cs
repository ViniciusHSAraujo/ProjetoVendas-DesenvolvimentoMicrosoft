using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VendasConsole.Utils.ValidaCPF;
using static VendasConsole.Program;

namespace VendasConsole {
    abstract class Pessoa {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataCadastro { get; set; }

        public abstract bool IsNovoID(int id);
        public abstract bool IsNovoCPF(String cpf);

        public override string ToString() {
            return $"ID: {Id}\n" +
                   $"NOME: {Nome}\n" +
                   $"CPF: {CPF}\n\n";
        }
    }
}
