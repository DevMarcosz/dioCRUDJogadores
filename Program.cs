using System;

namespace DIO.Jogadores
{
    class Program
    {
        static JogadorRepositorio repositorio = new JogadorRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarJogadores();
                    break;

                    case "2":
                    InserirJogadores();
                    break;

                    case "3":
                    AtualizarJogador();
                    break;

                    case "4":
                    ExcluirJogador();
                    break;

                    case "5":
                    VizualizarJogador();
                    break;

                    case "C":
                    Console.Clear();
                    break;

                    default:
                     throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
       
       private static void VizualizarJogador()
       {
            Console.WriteLine("Digite o  id do jogador: ");
            int indiceJogador = int.Parse(Console.ReadLine());

            var jogador = repositorio.RetornaPorId(indiceJogador);
            Console.WriteLine(jogador);
       }
       
        private static void ExcluirJogador()
        {
            Console.WriteLine("Digite o Id do Jogador: ");
            int indiceJogador = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceJogador);
        }
        private static void AtualizarJogador()
        {
            Console.WriteLine("Digite o ID do jogador");
            int indiceJogador = int.Parse(Console.ReadLine());
        
            foreach(int i in Enum.GetValues(typeof(Nivel)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Nivel), i));
            }
            Console.WriteLine("Digite o nivel entre as opções acima: ");
            int entradaNivel = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do jogador: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o clube do jogador: ");
            string entradaClube = Console.ReadLine();

            Console.WriteLine("Digite a descrição do jogador: ");
            string entradaDescricao = Console.ReadLine();

            Jogador atualizaJogador = new Jogador(id: indiceJogador,
                                              nivel: (Nivel)entradaNivel,
                                              nome: entradaNome,
                                              clube: entradaClube,
                                              descricao: entradaDescricao);

            repositorio.Atualiza(indiceJogador, atualizaJogador);
        }
        private static void InserirJogadores()
        {
            Console.WriteLine("Inserir um novo jogador");
        
            foreach(int i in Enum.GetValues(typeof(Nivel)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Nivel), i));
            }
            Console.WriteLine("Digite o nivel entre as opções acima: ");
            int entradaNivel = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do jogador: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o clube do jogador: ");
            string entradaClube = Console.ReadLine();

            Console.WriteLine("Digite a descrição do jogador: ");
            string entradaDescricao = Console.ReadLine();

            Jogador novoJogador = new Jogador(id: repositorio.ProximoId(),
                                              nivel: (Nivel)entradaNivel,
                                              nome: entradaNome,
                                              clube: entradaClube,
                                              descricao: entradaDescricao);

            repositorio.Insere(novoJogador);
        }
        private static void ListarJogadores()
        {
            Console.WriteLine("Jogadores na lista: ");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogador cadastrado.");
                return;
            }

            foreach(var jogador in lista)
            {
                var excluido = jogador.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", jogador.retornaId(), jogador.retornaNome(), (excluido ? "Excluido" : ""));
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Os Melhores(as vezes nem tanto) Jogadores do mundo");
            Console.WriteLine("informe a opção desejada: ");

            Console.WriteLine("[1]- Listar Jogadores");
            Console.WriteLine("[2]- Inserir Novo Jogador");
            Console.WriteLine("[3]- Atualizar Jogador");
            Console.WriteLine("[4]- Deletar Jogador");
            Console.WriteLine("[5]- Visualizar Jogador");
            Console.WriteLine("[C]- Limpar Tela");
            Console.WriteLine("[X]- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
