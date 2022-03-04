using System;

namespace _01_03
{
    class Program
    {
        delegate int Operacao(int a, int b);
            
        static void Main(string[] args)
        {
            int a = 3;
            int b = 2;

            Operacao operacao = Somar;
            Console.WriteLine(operacao(a, b));
            operacao = Subtrair;
            Console.WriteLine(operacao(a, b));
            
            Console.ReadKey();
        }

        static int Somar(int a, int b)
        {
            Console.WriteLine($"Operação de somar a = {a} e b = {b}");
            return a + b;
        }
        
        static int Subtrair(int a, int b)
        {
            Console.WriteLine($"Operação de subtrair a = {a} e b = {b}");
            return a - b;
        }
    }
}