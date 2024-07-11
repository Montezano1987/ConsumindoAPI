
using PembaAPI.Consulente;
using PembaAPI.Medium;

namespace PembaAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu de Opções:");
                Console.WriteLine("1. Buscar todos os consulentes");
                Console.WriteLine("2. Buscar consulente por ID");
                Console.WriteLine("3. Criar novo consulente");
                Console.WriteLine("4. Atualizar consulente");
                Console.WriteLine("5. Deletar consulente");
                Console.WriteLine("6. Buscar todos os mediuns");
                Console.WriteLine("7. Buscar medium por ID");
                Console.WriteLine("8. Criar novo medium");
                Console.WriteLine("9. Atualizar medium");
                Console.WriteLine("10. Deletar medium");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    await BuscarTodosConsulente();
                }
                else if (opcao == "2")
                {
                    await BuscarPorIdConsulente();
                }
                else if (opcao == "3")
                {
                    await CriarConsulente();
                }
                else if (opcao == "4")
                {
                    await AtualizarConsulente();
                }
                else if (opcao == "5")
                {
                    await DeletarConsulente();
                }
                else if (opcao == "6")
                {
                    await BuscarTodosMedium();
                }
                else if (opcao == "7")
                {
                    await BuscarPorIdMedium();
                }
                else if (opcao == "8")
                {
                    await CriarMedium();
                }
                else if (opcao == "9")
                {
                    await AtualizarMedium();
                }
                else if (opcao == "10")
                {
                    await DeletarMedium();
                }
                else if (opcao == "0")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
        }

        public static async Task BuscarTodosConsulente()
        {
            var consulentes = await ConsulenteService.BuscarTodosConsulente();
            foreach (var consulente in consulentes)
            {
                Console.WriteLine($"ID: {consulente.Id}, Nome: {consulente.Nome}");
            }
        }

        public static async Task BuscarPorIdConsulente()
        {
            Console.Write("Digite o ID do medium: ");
            var id = int.Parse(Console.ReadLine());
            var consulente = await ConsulenteService.BuscarPorIdConsulente(id);
            Console.WriteLine($"ID: {consulente.Id}, Nome: {consulente.Nome}");
        }

        public static async Task CriarConsulente()
        {
            Console.Write("Digite o nome do medium: ");
            var nome = Console.ReadLine();
            Console.Write("Digite a data de nascimento (yyyy-MM-dd): ");
            var dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("O medium é prioritário? (true/false): ");
            var ehPrioritario = bool.Parse(Console.ReadLine());
            Console.Write("O medium é médium? (true/false): ");
            var ehMedium = bool.Parse(Console.ReadLine());

            var novoConsulente = new ConsulenteDTO
            {
                Nome = nome,
                DataCadastro = DateTime.Now,
                DataNascimento = dataNascimento,
                EhPrioritario = ehPrioritario,
                EhMedium = ehMedium
            };

            var consulenteCriado = await ConsulenteService.CriarConsulente(novoConsulente);
            Console.WriteLine($"Consulente criado com sucesso: ID: {consulenteCriado.Id}, Nome: {consulenteCriado.Nome}");
        }

        public static async Task AtualizarConsulente()
        {
            Console.Write("Digite o ID do medium que deseja atualizar: ");
            var id = int.Parse(Console.ReadLine());
            var consulente = await ConsulenteService.BuscarPorIdConsulente(id);

            if (consulente == null)
            {
                Console.WriteLine("Consulente não encontrado.");
                return;
            }

            Console.Write("Digite o novo nome do medium: ");
            consulente.Nome = Console.ReadLine();
            Console.Write("Digite a nova data de nascimento (yyyy-MM-dd): ");
            consulente.DataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("O medium é prioritário? (true/false): ");
            consulente.EhPrioritario = bool.Parse(Console.ReadLine());
            Console.Write("O medium é médium? (true/false): ");
            consulente.EhMedium = bool.Parse(Console.ReadLine());

            var consulenteAtualizado = await ConsulenteService.AtualizarConsulente(consulente);
            Console.WriteLine($"Consulente atualizado com sucesso: ID: {consulenteAtualizado.Id}, Nome: {consulenteAtualizado.Nome}");
        }

        public static async Task DeletarConsulente()
        {
            Console.Write("Digite o ID do medium que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            var sucesso = await ConsulenteService.DeletarConsulente(id);
            if (sucesso)
            {
                Console.WriteLine("Consulente deletado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao deletar medium.");
            }
        }

        public static async Task BuscarTodosMedium()
        {
            var mediuns = await MediumService.BuscarTodosMedium();
            foreach (var medium in mediuns)
            {
                Console.WriteLine($"ID: {medium.Id}, Nome: {medium.NomeMedium}");
            }
        }

        public static async Task BuscarPorIdMedium()
        {
            Console.Write("Digite o ID do medium: ");
            var id = int.Parse(Console.ReadLine());
            var medium = await MediumService.BuscarPorIdMedium(id);
            Console.WriteLine($"ID: {medium.Id}, Nome: {medium.NomeMedium}");
        }

        public static async Task CriarMedium()
        {
            Console.Write("Digite o nome do medium: ");
            var nome = Console.ReadLine();
            Console.Write("Digite a data de nascimento (yyyy-MM-dd): ");
            var dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Quantidade de consultas maximas por dia?");
            var qtdConsultasMaxDiarias = int.Parse(Console.ReadLine());
            Console.Write("Qual o lado do medium?:");
            string lado = (Console.ReadLine());
            Console.Write("Qual a ordem do medium?:");
            int ordem = int.Parse(Console.ReadLine());

            var novoMedium = new MediumDTO
            {
                NomeMedium = nome,
                DataCadastro = DateTime.Now,
                DataNascimento = dataNascimento,
                QtdConsultasMaxDiarias = qtdConsultasMaxDiarias,
                Lado = lado,
                Ordem = ordem
            };

            var mediumCriado = await MediumService.CriarMedium(novoMedium);
            Console.WriteLine($"Medium criado com sucesso: ID: {mediumCriado.Id}, Nome: {mediumCriado.NomeMedium}");
        }

        public static async Task AtualizarMedium()
        {
            Console.Write("Digite o ID do medium que deseja atualizar: ");
            var id = int.Parse(Console.ReadLine());
            var medium = await MediumService.BuscarPorIdMedium(id);

            if (medium == null)
            {
                Console.WriteLine("Medium não encontrado.");
                return;
            }

            Console.Write("Digite o novo nome do medium: ");
            medium.NomeMedium = Console.ReadLine();
            Console.Write("Digite a nova data de nascimento (yyyy-MM-dd): ");
            medium.DataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("Qual o lado do medium?:");
            medium.Lado = (Console.ReadLine());
            Console.Write("Qual a ordem do medium?:");
            medium.Ordem = int.Parse(Console.ReadLine());

            var mediumAtualizado = await MediumService.AtualizarMedium(medium);
            Console.WriteLine($"Consulente atualizado com sucesso: ID: {mediumAtualizado.Id}, Nome: {mediumAtualizado.NomeMedium}");
        }

        public static async Task DeletarMedium()
        {
            Console.Write("Digite o ID do medium que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            var sucesso = await MediumService.DeletarMedium(id);
            if (sucesso)
            {
                Console.WriteLine("Medium deletado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao deletar medium.");
            }
        }
    }
}