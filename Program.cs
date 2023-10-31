using crud_simples.Entities;
using crud_simples.Entities.Exceptions;

namespace crud_simples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario.Usuarios.Add(new Usuario(1, "Pedro", "pedro@gmail.com"));
            Usuario.Usuarios.Add(new Usuario(2, "Bruno", "bruno@gmail.com"));
            Usuario.Usuarios.Add(new Usuario(3, "João", "joao@gmail.com"));
            Usuario.Usuarios.Add(new Usuario(4, "Gabriel", "joao@gmail.com"));

            try
            {
                bool end = false;
                while (end == false)
                {
                    Console.Clear();
                    Console.WriteLine("Selecione uma opção:");
                    Console.WriteLine("[1] Visualizar usuários");
                    Console.WriteLine("[2] Registrar usuário");
                    Console.WriteLine("[3] Editar usuário");
                    Console.WriteLine("[4] Deletar usuário");
                    Console.WriteLine("[5] Sair");
                    Console.WriteLine();
                    string escolha = Console.ReadLine();

                    switch (escolha)
                    {
                        case "1":
                            Usuario.GetAll();
                            Console.WriteLine("Pressione qualquer tecla para continar.");
                            Console.ReadKey();
                            break;

                        case "2":
                            Usuario.Insert();
                            Console.WriteLine("Pressione qualquer tecla para continar.");
                            Console.ReadKey();
                            break;

                        case "3":
                            Usuario.Update();
                            Console.WriteLine("Pressione qualquer tecla para continar.");
                            Console.ReadKey();
                            break;

                        case "4":
                            Usuario.Delete();
                            Console.WriteLine("Pressione qualquer tecla para continar.");
                            Console.ReadKey();
                            break;

                        case "5":
                            end = true;
                            break;

                        default:
                            Console.WriteLine("Valor inválido.\n");
                            Console.WriteLine("Pressione qualquer tecla para continar.");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro inesperado:");
                Console.WriteLine(e.Message);
            }
        }
    }
}