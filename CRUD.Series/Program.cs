using System;

namespace CRUD.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio(); 
        static void Main(string[] args)
        {
            
            int opcaoDesejada = OberOpcaoDoUsuario();

            while(opcaoDesejada != 7) {
                switch (opcaoDesejada)
                {
                    case 1:
                        ListarSeries();
                        break;
                    case 2:
                        InserirNovaSerie();
                        break;
                    case 3:
                        AtualizarSerie();
                        break;
                    case 4:
                        ExcluirSerie();
                        break;
                    case 5:
                        VisualziarSerie();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    default:
                        break;
                }

                opcaoDesejada = OberOpcaoDoUsuario();

            }
        }

        private static Serie CriarNovaSerie(int id = 0) 
        {
            Console.WriteLine("Escolha um tipo de genêro: ");
            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("   {0} - {1}", item, Enum.GetName(typeof(Genero), item));
            }

            int entradaGenero = Int16.Parse(Console.ReadLine());

            Console.Write("\nInsiera o titulo da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o Ano de lançamento da série: ");
            int entradaAno = Int16.Parse(Console.ReadLine());

            Console.Write("Insira a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            if(id == 0) id = repositorio.ProximoId(); 

            return new Serie(
                    id,
                    ((Genero)entradaGenero),
                    entradaTitulo,
                    entradaDescricao,
                    entradaAno
                    );
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            repositorio.Lista().ForEach(Console.WriteLine);
        }

        private static void InserirNovaSerie()
        {
            Console.WriteLine("Inserir uma nova série!");

            repositorio.Insere(
                CriarNovaSerie()
            );
            
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Série");

            Console.Write("Por favor informe o id da série a ser atualizada: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Atualizar(indiceSerie, CriarNovaSerie(indiceSerie));

        }
        private static void ExcluirSerie()
        {
            
            Console.WriteLine("Deletar série");

            Console.Write("Por favor informe o id da série a ser deletada: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Lista().Find(serie => serie.Id == indiceSerie).Excluir();
            Console.WriteLine("Série excluida !");
            
        }
        private static void VisualziarSerie()
        {
            Console.WriteLine("Marcar Série como assistida");

            Console.Write("Por favor informe o id da série a ser deletada: ");
            int indiceSerie = int.Parse(Console.ReadLine()); 
            repositorio.Lista().Find(serie => serie.Id == indiceSerie).Excluir();

            Console.WriteLine("Série assistida!");

        }

        private static int OberOpcaoDoUsuario()
        {
            string[,] arrDeOpcoes = {
                {"1", "Listar séries"},
                {"2", "Inserir nova série"},
                {"3", "Atualizar série"},
                {"4", "Excluir série"},
                {"5", "Visualizar série"},
                {"6", "Limpar tela"},
                {"7", "Sair"}
            };


            Console.WriteLine();
            Console.WriteLine("DDD Séries ao seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            for (int i = 0; i < arrDeOpcoes.Length /2 ; i++)
            {
                Console.WriteLine("[{0}] - {1}", arrDeOpcoes[i,0], arrDeOpcoes[i,1]);
            }

            return Int16.Parse(Console.ReadLine());
        }
    }
}
