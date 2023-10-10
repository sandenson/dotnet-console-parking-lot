using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new();
        private readonly Regex regexAntigo = new(@"^[a-z]{3}-?\d{4}$", RegexOptions.IgnoreCase);
        private readonly Regex regexMercosul = new(@"^[a-z]{3}[0-9][0-9a-z][0-9]{2}$", RegexOptions.IgnoreCase);

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        #nullable enable
        private string VerificarEFormatarPlaca(string? placa) {
        #nullable disable
            switch (Utils.VerificarNullish(placa).ToUpper())
            {
                case var oldFormat when regexAntigo.IsMatch(oldFormat!):
                    if (!oldFormat.Contains('-')) {
                        return oldFormat.Insert(3, "-");
                    }
                    return oldFormat;
                case var mercosulFormat when regexMercosul.IsMatch(mercosulFormat):
                    return mercosulFormat;
                default:
                    throw new ArgumentException($"Código de placa inválido: {placa}");
            }
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            try {
                string entrada = Console.ReadLine();
                string placa = this.VerificarEFormatarPlaca(entrada);

                if (veiculos.Any(x => x == placa)) {
                    throw new Exception($"Já existe um carro com a seguinte placa estacionado: {placa}");
                }
                veiculos.Add(placa);
            } catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        }

        public void RemoverVeiculo() {
            Console.WriteLine("Digite a placa do veículo a ser removido:");

            string entrada = Console.ReadLine();
            string placa = this.VerificarEFormatarPlaca(entrada);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa)) {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                string entradaHoras = "";
                
                try {
                    entradaHoras = Utils.VerificarNullish(Console.ReadLine());
                } catch (Exception err) {
                    Console.WriteLine(err.Message);
                    return;
                }

                if (!int.TryParse(entradaHoras, out int horas)) {
                    Console.WriteLine($"Valor de horas inválido! Tente novamente.");
                    return;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas; 

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            } else {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos() {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()) {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (var item in veiculos) {
                    Console.WriteLine($"- {item}");
                }
            } else {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
