using crud_simples.Entities.Exceptions;

namespace crud_simples.Entities
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public static List<Usuario> UsuariosDeletados { get; set; } = new List<Usuario>();

        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários:");
            foreach (var usuario in Usuarios)
            {
                Console.WriteLine(usuario);
                Console.WriteLine();
            }
        }

        public static void Insert()
        {
            Console.Clear();
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();

                if (nome == null || nome.Length == 1 || email == null || !email.Contains("@") || !email.Contains(".com"))
                    throw new DomainException("Digite valores válidos.");

                int nextId = Usuarios.LastOrDefault().Id + 1;

                Usuarios.Add(new Usuario(nextId, nome, email));

                Console.Clear();
                Console.WriteLine("Usuário registrado com sucesso!");
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }

        public static void Update()
        {
            try
            {
                Console.Clear();
                GetAll();
                Console.WriteLine();
                Console.Write("Digite o Id do usuário para editar: ");
                int id = int.Parse(Console.ReadLine());

                if (id == null)
                    throw new DomainException("Digite algum Id.");
                else if (UsuariosDeletados.Any(x => x.Id == id))
                    throw new DomainException("Usuário não encontrado.");

                Usuario user = Usuarios.Find(x => x.Id == id);

                int nextId = Usuarios.LastOrDefault().Id + 1;

                if (id == 0 || id >= nextId || user.Id == null)
                    throw new DomainException("Usuário não encontrado.");
                else
                {
                    Console.Write("Nome: ");
                    string name = Console.ReadLine();
                    if (name == null || name.Length == 1)
                        throw new DomainException("Digite um nome válido.");
                    user.Nome = name;

                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    if (email == null || !email.Contains("@") || !email.Contains(".com"))
                        throw new DomainException("Digite um email válido.");
                    user.Email = email;

                    Console.WriteLine();
                    Console.WriteLine("Usuário atualizado!");
                };

            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }

        public static void Delete()
        {
            Console.Clear();
            try
            {
                GetAll();
                Console.WriteLine();
                Console.Write("Digite o Id do usuário para deletar: ");
                int id = int.Parse(Console.ReadLine());

                int nextId = Usuarios.LastOrDefault().Id + 1;
                Usuario usuario = Usuarios.Find(x => x.Id == id);

                if (id == null || id == 0 || id >= nextId || UsuariosDeletados.Any(x => x.Id == id))
                    throw new DomainException("Usuário não encontrado.");
                else if (Usuarios.Count == 1)
                    throw new DomainException("A lista deve conter ao menos um usuário.");

                else
                {
                    UsuariosDeletados.Add(usuario);
                    Usuarios.Remove(usuario);
                    Console.WriteLine("Usuário deletado.");
                }
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Nome}\nEmail: {Email}";
        }
    }
}
