using System;
using System.Linq;
using System.Collections.Generic;

namespace ValidaCpfCnpj
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string cpf = "019336638";
            cpf.ToList().ForEach(x => numbers.Add(int.Parse(x.ToString())));            

            var multiplicador = 10;
            int soma = 0;

            numbers.ForEach(x => { soma += x * multiplicador; multiplicador--; });

            int dig10 = 11 - (soma % 11);
            if (dig10 > 9)
            {
                dig10 = 0;
            } 

            numbers.RemoveAt(0);
            numbers.Add(dig10); 

            multiplicador = 10;
            soma = 0;

            numbers.ForEach(x => { soma += x * multiplicador; multiplicador--; });

            int dig11 = 11 - (soma % 11);
            if (dig11 > 9)
            {
                dig11 = 0;
            }             

            Console.WriteLine($"{cpf}-{dig10}{dig11}");
        }
    }
}
