﻿using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Application.Service;
using BILTIFUL.Core.Entidades;
using System;

namespace BILTIFUL
{
    public class Program
    {
        static void Main(string[] args)
        {

            /*Repository<MPrima> repository = new Repository<MPrima>("MPrima.dat");

            repository.Add(new MPrima("Teste", Core.Entidades.Enums.Situacao.Inativo));

            foreach (var p in repository.GetAll())
                Console.WriteLine(p.Dados());

            Console.WriteLine(repository.GetByWhere(c => c.Nome == "teste2").Dados());

            Console.ReadKey();*/

            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t __________________________________________________");
            Console.WriteLine("\t\t\t\t\t|+++++++++++++++++++| BILTIFUL |+++++++++++++++++++|");
            Console.WriteLine("\t\t\t\t\t|1| - PRODUCAO                                     |");
            Console.WriteLine("\t\t\t\t\t|2| - COMPRA                                       |");
            Console.WriteLine("\t\t\t\t\t|3| - VENDA                                        |");
            Console.WriteLine("\t\t\t\t\t|4| - CADASTRO                                     |");
            Console.WriteLine("\t\t\t\t\t|0| - SAIR                                         |");
            Console.Write("\t\t\t\t\t|__________________________________________________|\n" +
                          "\t\t\t\t\t|Opção: ");


            string option = Console.ReadLine();

            switch (option)
            {
                case "0": Environment.Exit(0); break;

                case "1":
                    Console.Clear();
                    new ProducaoService().SubMenu();
                    BackMenu();
                    break;

                case "2":
                    Console.Clear();
                    BackMenu();
                    break;

                case "3":
                    Console.Clear();
                    BackMenu();
                    break;

                case "4":
                    Console.Clear();
                    new CadastroService().SubMenu();
                    BackMenu();
                    break;

                default:
                    Console.WriteLine("\t\t\t\tOpção inválida! ");
                    BackMenu();
                    break;
            }

        }

        public static void BackMenu()
        {
            Console.WriteLine("\n\t\t\t\t Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
