using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Group> list =
            [
                new Group("Metallica"),
                new Group("Queen"),
                new Group("Led Zeppelin"),
                new Group("Luccas")
            ];
            Random r= new Random();
            
            list.ForEach(group =>
            {
                group.Grades.Add(r.Next(1, 11));
                group.Grades.Add(r.Next(1, 11));
                group.Grades.Add(r.Next(1, 11));
            });
            ExibirMenu(list);
        }

        static int ToConvert()
        {
            string? v = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(v)) return -1;
            return int.Parse(v);
        }

        static void ExibirImagem()
        {
            Console.Clear();
            Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
        }

        static void Encerrando()
        {
            Console.Clear();
            Console.WriteLine(@"
                        
███████╗███╗░░██╗░█████╗░███████╗██████╗░██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░  ░█████╗░
██╔════╝████╗░██║██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗  ██╔══██╗
█████╗░░██╔██╗██║██║░░╚═╝█████╗░░██████╔╝██████╔╝███████║██╔██╗██║██║░░██║██║░░██║  ██║░░██║
██╔══╝░░██║╚████║██║░░██╗██╔══╝░░██╔══██╗██╔══██╗██╔══██║██║╚████║██║░░██║██║░░██║  ██║░░██║
███████╗██║░╚███║╚█████╔╝███████╗██║░░██║██║░░██║██║░░██║██║░╚███║██████╔╝╚█████╔╝  ╚█████╔╝
╚══════╝╚═╝░░╚══╝░╚════╝░╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░░╚════╝░  ░╚════╝░

░██████╗██╗░██████╗████████╗███████╗███╗░░░███╗░█████╗░
██╔════╝██║██╔════╝╚══██╔══╝██╔════╝████╗░████║██╔══██╗
╚█████╗░██║╚█████╗░░░░██║░░░█████╗░░██╔████╔██║███████║
░╚═══██╗██║░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║██╔══██║
██████╔╝██║██████╔╝░░░██║░░░███████╗██║░╚═╝░██║██║░░██║
╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝
");
        }

        static void ExibirMenu(List<Group> lists)
        {
            List<Group> list = lists;
            Command command = new Command();
            do
            {
                ExibirImagem();
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.WriteLine("Digite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("Digite 0 para sair");
                Console.Write("\nDigite uma opção: ");
                int option = ToConvert();

                switch (option)
                {
                    case 1:
                        ExibirImagem();
                        command.Execute(new RegistrarBanda(list));
                        break;
                    case 2:
                        ExibirImagem();
                        command.Execute(new ListarBandas(list));
                        break;
                    case 3:
                        ExibirImagem();
                        command.Execute(new AvaliarBanda(list));
                        break;
                    case 4:
                        ExibirImagem();
                        command.Execute(new ExibirMediaDaBanda(list));
                        break;
                    case 0:
                        Encerrando();
                        return;
                    default:
                        ExibirImagem();
                        Console.WriteLine("Opcao Invalida");
                        Thread.Sleep(2000);
                        break;
                }
            } while (true);



        }
        public class Group
        {
            public string Title { get; set; }
            public List<int> Grades { get; set; }

            public Group(string t)
            {
                this.Title = t;
                this.Grades = new List<int>();
            }
        }

        public interface ICommand
        {
            void Execute();
        }

        public class Command
        {
            public void Execute(ICommand command)
            {
                command.Execute();
            }
        }

        public class RegistrarBanda : ICommand
        {
            private List<Group> List;

            public RegistrarBanda(List<Group> list)
            {
                this.List = list;
            }

            public void Execute()
            {
                Console.WriteLine("\n");
                Console.WriteLine(@"
█▀█ █▀▀ █▀▀ █ █▀ ▀█▀ █▀█ █▀█   █▀▄ █▀▀   █▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█
█▀▄ ██▄ █▄█ █ ▄█ ░█░ █▀▄ █▄█   █▄▀ ██▄   █▄█ █▀█ █░▀█ █▄▀ █▀█");
                Console.Write("\nDigite o nome da Banda: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) return;
                List.Add(new Group(name));
                Console.WriteLine($"\nBanda {name} foi registrada com Sucesso");
                Thread.Sleep(500);
            }
        }

        public class ListarBandas : ICommand
        {
            private List<Group> List;

            public ListarBandas(List<Group> list)
            {
                this.List = list;
            }

            public void Execute()
            {
                Console.WriteLine(@"

█░░ █ █▀ ▀█▀ ▄▀█ █▀▀ █▀▀ █▀▄▀█   █▀▄ █▀▀   █▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█ █▀
█▄▄ █ ▄█ ░█░ █▀█ █▄█ ██▄ █░▀░█   █▄▀ ██▄   █▄█ █▀█ █░▀█ █▄▀ █▀█ ▄█");
                Console.WriteLine("\n");
                List.ForEach(x =>
                {
                    Console.WriteLine(x.Title);
                });
                Console.Write("\nPressione uma tecla qualquer para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(@"

██████╗░░█████╗░░█████╗░  ██╗░░██╗░█████╗░███╗░░░███╗███████╗██████╗░
██╔══██╗██╔══██╗██╔══██╗  ██║░░██║██╔══██╗████╗░████║██╔════╝██╔══██╗
██████╦╝██║░░██║███████║  ███████║██║░░██║██╔████╔██║█████╗░░██████╔╝
██╔══██╗██║░░██║██╔══██║  ██╔══██║██║░░██║██║╚██╔╝██║██╔══╝░░██╔══██╗
██████╦╝╚█████╔╝██║░░██║  ██║░░██║╚█████╔╝██║░╚═╝░██║███████╗██║░░██║
╚═════╝░░╚════╝░╚═╝░░╚═╝  ╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚═╝

░██████╗██╗███╗░░░███╗██████╗░░██████╗░█████╗░███╗░░██╗██╗██╗
██╔════╝██║████╗░████║██╔══██╗██╔════╝██╔══██╗████╗░██║██║██║
╚█████╗░██║██╔████╔██║██████╔╝╚█████╗░██║░░██║██╔██╗██║██║██║
░╚═══██╗██║██║╚██╔╝██║██╔═══╝░░╚═══██╗██║░░██║██║╚████║╚═╝╚═╝
██████╔╝██║██║░╚═╝░██║██║░░░░░██████╔╝╚█████╔╝██║░╚███║██╗██╗
╚═════╝░╚═╝╚═╝░░░░░╚═╝╚═╝░░░░░╚═════╝░░╚════╝░╚═╝░░╚══╝╚═╝╚═╝");
                Thread.Sleep(1500);
            }
        }

        public class AvaliarBanda : ICommand
        {
            private List<Group> List;

            public AvaliarBanda(List<Group> list)
            {
                this.List = list;
            }

            public void Execute()
            {
                Console.WriteLine(@"

▄▀█ █░█ ▄▀█ █░░ █ ▄▀█ █▀█   █▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█
█▀█ ▀▄▀ █▀█ █▄▄ █ █▀█ █▀▄   █▄█ █▀█ █░▀█ █▄▀ █▀█");
                Console.Write("Digite o nome da banda que deseja avaliar: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) return;
                if (!List.Any(Group => Group.Title.Equals(name)))
                {
                    Console.WriteLine("Banda nao registrada");
                    Thread.Sleep(1500);
                    return;
                }
                Console.WriteLine("\nEm uma nota de 1 a 10");
                Console.Write($"Qual a nota que a banda {name} merece: ");
                int nota = ToConvert();
                if (nota < 1 || nota > 10) return;
                Group group = List.Find(group => group.Title == name)!;
                group.Grades.Add(nota);
                Console.WriteLine($"\nBanda {name} avaliada com Sucesso!!");
                Thread.Sleep(1000);
                
            }

        }

        public class ExibirMediaDaBanda : ICommand
        {
            private List<Group> List;

            public ExibirMediaDaBanda(List<Group> list)
            {
                List = list;
            }

            public void Execute()
            {
                Console.Write("Digite o nome da banda que deseja Exibir Media: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) return;
                if (!List.Any(Group => Group.Title.Equals(name)))
                {
                    Console.WriteLine("Banda nao registrada");
                    Thread.Sleep(1500);
                    return;
                }
                Group group = List.Find(group => group.Title == name)!;
                double average = group.Grades.Average();
                Console.Clear();
                Console.WriteLine(@"

█▀▀ ▀▄▀ █ █▄▄ █ █▀█   █▀▄▀█ █▀▀ █▀▄ █ ▄▀█   █▀▄ ▄▀█   █▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█
██▄ █░█ █ █▄█ █ █▀▄   █░▀░█ ██▄ █▄▀ █ █▀█   █▄▀ █▀█   █▄█ █▀█ █░▀█ █▄▀ █▀█");
                Console.WriteLine($"A Banda {name} tem uma media de avaliação de: {average}");
                Console.Write("\nPressione uma tecla qualquer para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(@"

██████╗░░█████╗░░█████╗░  ██╗░░██╗░█████╗░███╗░░░███╗███████╗██████╗░
██╔══██╗██╔══██╗██╔══██╗  ██║░░██║██╔══██╗████╗░████║██╔════╝██╔══██╗
██████╦╝██║░░██║███████║  ███████║██║░░██║██╔████╔██║█████╗░░██████╔╝
██╔══██╗██║░░██║██╔══██║  ██╔══██║██║░░██║██║╚██╔╝██║██╔══╝░░██╔══██╗
██████╦╝╚█████╔╝██║░░██║  ██║░░██║╚█████╔╝██║░╚═╝░██║███████╗██║░░██║
╚═════╝░░╚════╝░╚═╝░░╚═╝  ╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚═╝

░██████╗██╗███╗░░░███╗██████╗░░██████╗░█████╗░███╗░░██╗██╗██╗
██╔════╝██║████╗░████║██╔══██╗██╔════╝██╔══██╗████╗░██║██║██║
╚█████╗░██║██╔████╔██║██████╔╝╚█████╗░██║░░██║██╔██╗██║██║██║
░╚═══██╗██║██║╚██╔╝██║██╔═══╝░░╚═══██╗██║░░██║██║╚████║╚═╝╚═╝
██████╔╝██║██║░╚═╝░██║██║░░░░░██████╔╝╚█████╔╝██║░╚███║██╗██╗
╚═════╝░╚═╝╚═╝░░░░░╚═╝╚═╝░░░░░╚═════╝░░╚════╝░╚═╝░░╚══╝╚═╝╚═╝");
                Thread.Sleep(2000);
            }
        }
    }
}
