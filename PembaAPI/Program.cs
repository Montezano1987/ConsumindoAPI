
using PembaAPI.Consulente;

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
                //else if (opcao == "3")
                //{
                //    await CriarConsulente();
                //}
                //else if (opcao == "4")
                //{
                //    await AtualizarConsulente();
                //}
                //else if (opcao == "5")
                //{
                //    await DeletarConsulente();
                //}
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
            Console.Write("Digite o ID do consulente: ");
            var id = int.Parse(Console.ReadLine());
            var consulente = await ConsulenteService.BuscarPorIdConsulente(id);
            Console.WriteLine($"ID: {consulente.Id}, Nome: {consulente.Nome}");
        }

    }
}