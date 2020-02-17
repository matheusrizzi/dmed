using System;
using Dmed.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dmed.Testes.Entidades
{
    [TestClass]
    public class DeclaracaoTeste
    {
        [TestMethod]
        public void RetornarErroSeDeclaracaoRetificadoraSemRecibo()
        {
            var x = new Declaracao(2020,2019,"","", true);
            Assert.IsTrue(x.Invalid);
        }

        [TestMethod]
        public void RetornarSucessoSeDeclaracaoRetificadoraComRecibo()
        {
            var x = new Declaracao(2020, 2019, "1233131", "", true);
            Assert.IsTrue(x.Valid);
        }

        [TestMethod]
        [DataRow(2021)]
        [DataRow(2022)]
        [DataRow(2023)]
        [DataRow(2024)]
        public void RetornarErroSeAnoCalendarioMaiorQueAnoReferencia(int anoCalendario)
        {
            var x = new Declaracao(2020, anoCalendario, "", "", false);
            Assert.IsTrue(x.Invalid);
        }

        [TestMethod]
        [DataRow(2020)]
        [DataRow(2019)]
        [DataRow(2018)]
        [DataRow(2017)]
        public void RetornarSucessoSeAnoCalendarioMenorOuIgualAnoCalendario(int anoReferencia)
        {
            var x = new Declaracao(2020, anoReferencia, "", "", false);
            Assert.IsTrue(x.Valid);
        }

        [TestMethod]
        public void RetornarErroSeAnoReferenciaZero()
        {
            var x = new Declaracao(2020, 0, "", "", false);
            Assert.IsTrue(x.Invalid);
        }

        [TestMethod]
        public void RetornarErroSeAnoCalendarioZero()
        {
            var x = new Declaracao(0, 2020, "", "", false);
            Assert.IsTrue(x.Invalid);
        }
    }
}
