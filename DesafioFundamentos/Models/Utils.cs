using System.ComponentModel;

namespace DesafioFundamentos.Models
{
    public class Utils
    {
        public static void PressioneParaContinuar () {
            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        // Baseado em https://stackoverflow.com/a/35554808
        public static void ColetarEConverterValor<T> (out T valor, string mensagem) {
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
        }

        #nullable enable
        public static string VerificarNullish (string? texto) {
        #nullable disable
            if (String.IsNullOrWhiteSpace(texto?.Trim())) {
                throw new ArgumentException("Insira um valor!");
            }
            return texto!;
        }
    }
}