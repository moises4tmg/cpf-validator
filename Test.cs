using System;

namespace cpf
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Console.Write("CPF (###.###.###-##): ");
            string result = CpfValidator.validaCPF(Console.ReadLine()) ? "CPF Válido" : "CPF Inválido";
            Console.WriteLine(result);
        }
    }
}