using System;
using System.IO;

namespace MainApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("\nO que você deseja fazer ?");
            Console.WriteLine("1 - Abrir um Arquivo" +
                              "\n2 - Editar um Arquivo" +
                              "\n0 - Sair");
            Console.WriteLine("\n==============================");

            short escolha = short.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default:
                    Console.WriteLine("\nTente escolher novamente!");
                    Menu();
                    break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o Caminho do Arquivo?");

            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Insira seu texto aqui: (END para sair)");
            Console.WriteLine("_______________________________________");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;

            } while (Console.ReadKey().Key != ConsoleKey.End);
            
            Salvar(text);
            
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Onde deseja Salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}