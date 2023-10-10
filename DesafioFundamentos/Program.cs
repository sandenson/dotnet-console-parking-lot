using System.ComponentModel;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

void PressioneParaContinuar () {
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

// Baseado em https://stackoverflow.com/a/35554808
void ColetarEConverterValor<T> (out T valor, string mensagem) {
    bool sucesso = false;
    valor = default(T);

    while (!sucesso) {
        TypeConverter conversor = TypeDescriptor.GetConverter(typeof(T));
        
        if (conversor != null) {
            try {
                Console.WriteLine(mensagem);
                valor = (T)conversor.ConvertFromString(Console.ReadLine());
                sucesso = true;
            } catch (Exception) {
                Console.WriteLine("Valor inválido! Tente novamente.");
                PressioneParaContinuar();
            }
        } else {
            throw new ArgumentException("Tipo de valor inválido", typeof(T).Name);
        }
    }

    Console.WriteLine($"\nSUCESSO PORRA\n{valor} - {typeof(T).Name}\n");
}

ColetarEConverterValor(out decimal precoInicial, "Digite o preço inicial:");

ColetarEConverterValor(out decimal precoPorHora, "Agora digite o preço por hora:");

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    PressioneParaContinuar();
}

Console.WriteLine("O programa se encerrou");
