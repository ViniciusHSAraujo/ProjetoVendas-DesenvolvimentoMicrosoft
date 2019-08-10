using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace VendasConsole {
    class Program {
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Vendedor> Vendedores = new List<Vendedor>();
        public static List<Produto> Produtos = new List<Produto>();
        public static List<Venda> Vendas = new List<Venda>();
        static void Main(string[] args) {
            int opcao;
            bool continuar = true;
            do {
                Clear();
                Title = "Sistema de Vendas";
                WriteLine("##############Sistema de Vendas##############");
                WriteLine("Escolha uma das opções abaixo");
                WriteLine("1 - Cadastrar Cliente");
                WriteLine("2 - Listar Clientes");
                WriteLine("3 - Cadastrar Vendedor");
                WriteLine("4 - Listar Vendedores");
                WriteLine("5 - Cadastrar Produto");
                WriteLine("6 - Listar Produtos");
                WriteLine("7 - Cadastrar Venda");
                WriteLine("8 - Listar Vendas");
                WriteLine("9 - Listar Vendas Por Cliente");
                WriteLine("0 - Sair");
                opcao = Convert.ToInt32(ReadLine());
                switch (opcao) {
                    case 1:
                        Clear();
                        CadastrarCliente();
                        break;
                    case 2:
                        Clear();
                        ListarClientes();
                        break;
                    case 3:
                        Clear();
                        CadastrarVendedor();
                        break;
                    case 4:
                        Clear();
                        ListarVendedores();
                        break;
                    case 5:
                        Clear();
                        CadastrarProduto();
                        break;
                    case 6:
                        Clear();
                        ListarProdutos();
                        break;
                    case 7:
                        Clear();
                        RegistrarVenda();
                        break;
                    case 8:
                        Clear();
                        ListarVendas();
                        break;
                    case 9:
                        Clear();
                        ListarVendasPorCliente();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        break;
                }

            } while (continuar);
        }
        public static void CadastrarCliente() {
            Title = "Cadastro de Clientes:";

            WriteLine("Digite o ID do Cliente");
            int id = Convert.ToInt32(ReadLine());

            WriteLine("Digite o nome do Cliente");
            string nome = ReadLine();

            WriteLine("Digite o CPF do Cliente");
            string cpf = ReadLine();

            try {
                Clientes.Add(new Cliente(id, nome, cpf));
                WriteLine("Cliente cadastrado com sucesso");
            }catch(Exception e) {
                WriteLine($"Erro ao cadastrar: {e.Message}");
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void ListarClientes() {
            Title = "Listagem de Clientes:";

            foreach (var cliente in Clientes) {
                WriteLine(cliente);
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void CadastrarVendedor() {
            Title = "Cadastro de Vendedor:";

            WriteLine("Digite o ID do Vendedor");
            int id = Convert.ToInt32(ReadLine());

            WriteLine("Digite o nome do Vendedor");
            string nome = ReadLine();

            WriteLine("Digite o CPF do Vendedor");
            string cpf = ReadLine();

            try {
                Vendedores.Add(new Vendedor(id, nome, cpf));
                WriteLine("Vendedor cadastrado com sucesso");
            } catch (Exception e) {
                WriteLine($"Erro ao cadastrar: {e.Message}");
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void ListarVendedores() {
            Title = "Listagem de Vendedores:";

            foreach (var vendedor in Vendedores) {
                WriteLine(vendedor);
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void CadastrarProduto() {
            Title = "Cadastro de Produtos:";


            WriteLine("Digite o ID do Produto");
            int id = Convert.ToInt32(ReadLine());

            WriteLine("Digite o nome do produto");
            string nome = ReadLine();

            WriteLine("Digite o valor do produto");
            double preco = Convert.ToDouble(ReadLine());

            WriteLine("Digite a quantidade do produto");
            int quantidade = Convert.ToInt32(ReadLine());


            try {
                Produtos.Add(new Produto(id, nome, preco, quantidade));
                WriteLine("Produto cadastrado com sucesso");
            } catch (Exception e) {
                WriteLine($"Erro ao cadastrar: {e.Message}");
            }


            WriteLine("\n\nPressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void ListarProdutos() {
            Title = "Listagem de Produtos:";

            foreach (var produto in Produtos) {
                WriteLine(produto);
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void RegistrarVenda() {
            Title = "Registro de Venda:";

            try {

            WriteLine("Digite o ID da Venda");
            int idVenda = Convert.ToInt32(ReadLine());

            WriteLine("Digite o ID do Cliente");
            int idCliente = Convert.ToInt32(ReadLine());
            var cliente = Clientes.First<Cliente>(c => c.Id == idCliente);

            WriteLine("Digite o ID do Vendedor");
            int idVendedor = Convert.ToInt32(ReadLine());

            var vendedor = Vendedores.First<Vendedor>(v => v.Id == idVendedor);

            var produtos = escolherProdutos();

                Vendas.Add(new Venda(idVenda, cliente, vendedor, produtos));
                WriteLine("Venda realizada com sucesso");
            } catch (Exception e) {
                WriteLine($"Erro ao realizar a venda: {e.Message}");
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void ListarVendas() {
            Title = "Listagem de Vendas:";

            foreach (var venda in Vendas) {
                WriteLine(venda);
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }
        public static void ListarVendasPorCliente() {
            Title = "Listagem de Vendas por Cliente:";

            WriteLine("Digite a ID do cliente que deseja filtrar as vendas:");
            int id = Convert.ToInt32(ReadLine());

            Clear();

            WriteLine($"Notas do Cliente {Clientes.First(c => c.Id == id).Nome}\n\n");

            foreach (var venda in Vendas.Where(c => c.Cliente.Id == id)) {
                WriteLine(venda);
            }

            WriteLine("Pressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }

        public static List<Produto> escolherProdutos() {
            List<Produto> produtosEscolhidos = new List<Produto>();
            int opcao;
            bool continuar = true;
            do {
                Clear();

                WriteLine("1 - Adicionar Produto");
                WriteLine("0 - Sair");
                opcao = Convert.ToInt32(ReadLine());
                switch (opcao) {
                    case 1:

                        WriteLine("Digite a ID do produto:");
                        int idProd = Convert.ToInt32(ReadLine());
                        Produto prodEscolhido = Produtos.First(p => p.Id == idProd);
                        WriteLine("Digite a quantidade desejada do produto:");
                        int qtdeProd = Convert.ToInt32(ReadLine());

                        if(prodEscolhido.Quantidade > qtdeProd) {
                            prodEscolhido.Quantidade -= qtdeProd;
                            Produto produtoCompra = new Produto(prodEscolhido.Nome, qtdeProd);
                            produtosEscolhidos.Add(produtoCompra);
                            WriteLine("Produto adicionado com sucesso em sua lista de compras.\n");
                        } else {
                            WriteLine("Quantidade indisponível.");
                        }


                        break;
                    default:
                        continuar = false;
                        break;
                }

            } while (continuar && produtosEscolhidos.Count() != 0);
            return produtosEscolhidos;
        }
    }
}
