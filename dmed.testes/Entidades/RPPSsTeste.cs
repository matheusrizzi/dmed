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
    public class RPPSsTeste
    {
        [TestMethod]
        public void ErroSeEstiverSemValorPago()
        {
            var servico = new RPPSS("043.867.340-90", "xpto", 0);
            Assert.IsTrue(servico.Invalid);
        }

        [TestMethod]
        public void ErroSeEstiverSemCpf()
        {
            var servico = new RPPSS("", "xpto", 1);
            Assert.IsTrue(servico.Invalid);
        }

        [TestMethod]
        public void ErroSeEstiverSemNome()
        {
            var servico = new RPPSS("04386734090", "", 1);
            Assert.IsTrue(servico.Invalid);
        }

        [TestMethod]
        public void SucessoRegistroComCamposObrigatorios()
        {
            var servico = new RPPSS("04386734090", "nome", 1);
            Assert.IsTrue(servico.Valid);
        }
    }
}
