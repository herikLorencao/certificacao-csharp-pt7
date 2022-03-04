using System;

namespace _01_04
{
    class Program
    {
        delegate int Operacao(int a, int b);
            
        static void Main(string[] args)
        {
            Operacao operacao = (x, y) => x + y;
            Console.WriteLine(operacao(3, 2));
        }
    }
}