using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CreateCpf.Core;

namespace CreateCpf.Teste
{
    public class GeradorCpfTeste
    {
        [Fact]
        public void GerarCpfManual()
        {
            GeradorCpf gerador = new GeradorCpf("160528349");
            Assert.Equal("160528349-51", gerador.GerarCpf());
        }

        [Fact]
        public void GerarCpfDinamico()
        {
            GeradorCpf gerador = new GeradorCpf();
            var numeroCpf = gerador.GerarCpf();
            Assert.True(numeroCpf.Length == 12);
        }
    }
}
