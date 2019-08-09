using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VendasConsole.Utils.ValidaCPF;
using static VendasConsole.Program;


namespace VendasConsole {
    class Vendedor : Pessoa {
        public Vendedor(int id, string nome, string cpf) {

            /**
             * Verifica se o CPF é válido e lança uma excessão caso o CPF seja inválido.
             */
            if (!IsCpf(cpf)) {
                throw new Exception("CPF Inválido!");
            }

            /**
             * Verifica se o ID já foi utilizado e lança uma excessão caso já tenha algum usuário com o mesmo ID.
             */
            if (!IsNovoID(id)) {
                throw new Exception("ID já utilizado");
            }

            /**
             * Verifica se o CPF já foi utilizado e lança uma excessão caso já tenha algum usuário com o mesmo CPF.
             */
            if (!IsNovoCPF(cpf)) {
                throw new Exception("Cliente já cadastrado");
            }

            Id = id;
            Nome = nome;
            CPF = cpf;
            DataCadastro = DateTime.Now;
        }

        public override bool IsNovoID(int id) {
            return !Vendedores.Any<Vendedor>(vdd => vdd.Id.Equals(id));
        }
        public override bool IsNovoCPF(String cpf) {
            return !Vendedores.Any<Vendedor>(vdd => vdd.CPF.Equals(cpf));
        }
        public Vendedor BuscarVendedorPeloID(int id) {
            return Vendedores.Find(vdd => vdd.Id == id);
        }

        public override string ToString() {
            return $"ID: {Id}\n" +
                   $"NOME: {Nome}\n" +
                   $"CPF: {CPF}\n\n";
        }
    }
}
