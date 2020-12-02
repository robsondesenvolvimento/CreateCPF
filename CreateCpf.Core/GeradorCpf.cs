using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CreateCpf.Core
{
    public class GeradorCpf
    {
        private List<int> _digitosCpf = new List<int>();
        private string _cpfCompleto;

        public GeradorCpf()
        {
            Random numeroAleatorio = new Random();
            var noveDigitosAleatorios = numeroAleatorio.Next(111111111, 999999999).ToString();
            Set9DigitosIniciais(noveDigitosAleatorios);
        }

        public GeradorCpf(string digitos)
        {
            Set9DigitosIniciais(digitos);
        }

        public void Set9DigitosIniciais(string digitos)
        {
            if (digitos.Trim().Length > 9)
                throw new ArgumentException("Número máximo de digitos é 9");

            if (Regex.IsMatch(digitos, ".*[a-zA-Z]+.*"))
                throw new ArgumentException("Só números são válidos no CPF");

            digitos.ToList().ForEach(digito =>
                {
                    var digitoAtual = Int32.Parse(digito.ToString());
                    _digitosCpf.Add(digitoAtual);
                }
            );

            _cpfCompleto = digitos;
        }

        public string GerarCpf()
        {
            var multiplicador = 10;
            var soma = 0;

            _digitosCpf.ForEach(digito =>
            {
                soma += digito * multiplicador;
                multiplicador--;
            });

            var decimoDigito = 11 - (soma % 11);

            if (decimoDigito > 9)
                decimoDigito = 0;

            _digitosCpf.RemoveAt(0);
            _digitosCpf.Add(decimoDigito);

            multiplicador = 10;
            soma = 0;

            _digitosCpf.ForEach(digito =>
            {
                soma += digito * multiplicador;
                multiplicador--;
            });

            var decimoPrimeiroDigito = 11 - (soma % 11);

            if (decimoPrimeiroDigito > 9)
                decimoPrimeiroDigito = 0;

            return $"{_cpfCompleto}-{decimoDigito}{decimoPrimeiroDigito}";
        }

    }
}
