using Dmed.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.Testes.Entidades
{
    [TestClass]
    public class ResponsavelTeste
    {
        [TestMethod]
        public void ErroSeResponsavelSemNome()
        {
            var resp = new Responsavel("710.130.560-19", "", "47", "888888888", "", "", "xpto@x.com.br");
            Assert.IsTrue(resp.Invalid);
        }

        [TestMethod]
        public void SucessoSeResponsavelComDadosObrigatoriosPreenchidos()
        {
            var resp = new Responsavel("710.130.560-19", "responsavelName", "47", "888888888", "", "", "xpto@x.com.br");
            Assert.IsTrue(resp.Valid);
        }

        [TestMethod]
        public void ErroSeResponsavelSemDDD()
        {
            var resp = new Responsavel("710.130.560-19", "responsavelName", "", "888888888", "", "", "xpto@x.com.br");
            Assert.IsTrue(resp.Invalid);
        }

        [TestMethod]
        public void ErroSeResponsavelSemTelefone()
        {
            var resp = new Responsavel("710.130.560-19", "responsavelName", "47", "", "", "", "xpto@x.com.br");
            Assert.IsTrue(resp.Invalid);
        }
    }
}
