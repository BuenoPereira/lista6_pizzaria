using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzariaIFSP
{
    internal class Program
    {
        static string Cin(string texto = "")
        {
            Console.Write(texto);
            return Console.ReadLine();
        }

        static Cliente cadastro()
        {
            string nome = Cin("\n Nome: ");
            string email = Cin("\n Email: ");
            string telefone = Cin("\n Telefone: ");
            DateTime datNasc;
            try
            {
            datNasc = Convert.ToDateTime(Cin("\n Data de nascimento: "));
            }
            catch
            {
                datNasc = new DateTime();
            }
            Cliente cli = new Cliente(nome,email, telefone, datNasc);
            return cli;
        }

        static Cliente Editar(Cliente Cliente)
        {
            string nome = Cin("\n Novo Nome: ");
            string email = Cin("\n Novo Email: ");
            string telefone = Cin("\n Novo Telefone: ");
            DateTime datNasc;
            try
            {
                datNasc = Convert.ToDateTime(Cin("\n Data de nascimento: "));
            }
            catch
            {
                datNasc = new DateTime();
            }
            Cliente.Set_atritutes(nome, email, telefone, datNasc);
            return Cliente;
        }


        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("SAIR -----------------  0");
            Console.WriteLine("CADASTRAR ------------  1");
            Console.WriteLine("LISTAR ---------------  2");
            Console.WriteLine("REMOVER --------------  3");
            Console.WriteLine("EDITAR ---------------  4");
            Console.WriteLine("Procurar por nome ----  5");
            try {
                return int.Parse(Console.ReadLine()); 
            }catch
            {
                return -1;             
            }
        }



        static void Main(string[] args)
        {
            
            int qtd = 0, opcao, id;
            string nome;
            Cliente[] vetCli = new Cliente[100];
            do
            {
                Console.Clear();
                opcao = Menu();
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Tchau!");
                        break;
                    case 1:
                        Console.WriteLine("NOVO CADASTRO");
                        vetCli[qtd++] = cadastro();
                        break;
                    case 2:
                        Console.WriteLine("LISTAR TODOS OS CADASTROS");
                        for (int i = 0; i < qtd; i++)
                        {
                            Console.WriteLine(vetCli[i].ToString());
                        }
                        Cin("\n\nPressione qualquer tecla para voltar ao menu...");
                        break;
                    case 3:
                        Console.WriteLine("REMOVER UM CADASTRO");
                        id = int.Parse(Cin("\nQual o id do cliente a ser removido? : "));
                        vetCli[id] = vetCli[qtd - 1];
                        qtd--;
                        break;


                    case 4:
                        Console.WriteLine("EDITAR UM CADASTRO");
                        id = int.Parse(Cin("\nQual o id do cliente a ser editado? : "));
                        Console.WriteLine("Cadastro a ser editado: ");
                        vetCli[id].ToString();
                        Console.WriteLine("informe os dados a serem alterados. Os campos em branco não serão alterados");
                        vetCli[id] = Editar(vetCli[id]);
                        break;
                    case 5:
                        Console.WriteLine("PROCURAR UM CADASTRO POR NOME");




                        nome = "";                        
                        ConsoleKeyInfo keyInfo;
                        Console.Clear();
                        Console.Write("\nNome digitado: ");
                        while (true)
                        {
                            keyInfo = Console.ReadKey();
                            if (keyInfo.Key == ConsoleKey.Backspace && nome.Length > 0) {
                                nome = nome.Substring(0, nome.Length - 1);
                            }
                            else if (keyInfo.Key == ConsoleKey.Enter) {
                                break;
                            }
                            else {
                                nome += keyInfo.KeyChar;
                            }
                            Console.Clear();
                            Console.WriteLine($"\nResultados para \"{nome}\": ");
                            int found_count = 0;
                            for (int i = 0; i < qtd; i++)
                            {
                                if (vetCli[i].get_nome().ToUpper().Contains(nome.ToUpper()))
                                {
                                    found_count++;
                                    Console.Write($"---   {found_count}   ---");
                                    Console.WriteLine(vetCli[i].ToString());
                                    Console.WriteLine("-------------------------------");
                                }
                            }
                            Console.Write($"Procurando: {nome}");
                        }



                        break;

                    default:
                        Console.WriteLine("\n\nOpção inválida!");
                        Thread.Sleep(800);
                        break;
                }

            } while (opcao != 0);









            Console.ReadKey();
        }
    }
}
