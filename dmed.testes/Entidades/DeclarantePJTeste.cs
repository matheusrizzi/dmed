using Dmed.Entidades;
using Dmed.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.Testes.Entidades
{
    [TestClass]
    public class DeclarantePJTeste
    {
        private readonly string _cnpjValido;

        public DeclarantePJTeste() => _cnpjValido = "89475225000108";

        [TestMethod]
        public void ErroDeclaranteCnpjInvalido()
        {
            var d = new DeclarantePJ("1232132131", "Teste", 
                                     Enums.ETipoDeclarante.Prestador_Servico_Saude, "", "", "37075050060", 
                                     ESituacaoDeclaracao.Situacao_Nao_Especial, "");
            Assert.IsTrue(d.Invalid);
        }

        [TestMethod]
        [DataRow("34.159.982/0001-80")]
        [DataRow("89475225000108")]
        public void SucessoDeclaranteCnpjValido(string cnpj)
        {
            var d = new DeclarantePJ(cnpj, "Teste", Enums.ETipoDeclarante.Prestador_Servico_Saude, 
                                     "", "", "37075050060", 
                                     ESituacaoDeclaracao.Situacao_Nao_Especial, "");
            Assert.IsTrue(d.Valid);
        }

        [TestMethod]
        public void ErroDeclaranteSemRazaoSocial()
        {
            var d = new DeclarantePJ("89475225000108", "", 
                                     Enums.ETipoDeclarante.Prestador_Servico_Saude, 
                                     "", "", "37075050060",  ESituacaoDeclaracao.Situacao_Nao_Especial, "");
            Assert.IsTrue(d.Invalid);
        }

        [TestMethod]
        [DataRow(ETipoDeclarante.Operadora_Plano_Privado_Assistencia_Saude)]
        [DataRow(ETipoDeclarante.Prestador_Servico_Saude_e_Operadora_Plano_Privado)]
        public void ErroSeRegistroAnsVazioParaDeclarante_2_ou_3(ETipoDeclarante tipoDeclarante)
        {
            var d = new DeclarantePJ(this._cnpjValido, "Teste", 
                                     tipoDeclarante, 
                                     "", "", "37075050060", ESituacaoDeclaracao.Situacao_Nao_Especial, "");
            Assert.IsTrue(d.Invalid);
        }

        [TestMethod]
        [DataRow(ETipoDeclarante.Operadora_Plano_Privado_Assistencia_Saude)]
        [DataRow(ETipoDeclarante.Prestador_Servico_Saude_e_Operadora_Plano_Privado)]
        public void SucessoSeRegistroAnsPreenchidoParaDeclarante_2_ou_3(ETipoDeclarante tipoDeclarante)
        {
            var d = new DeclarantePJ(this._cnpjValido, "Teste",
                                     tipoDeclarante,
                                     "434354", "", "37075050060", ESituacaoDeclaracao.Situacao_Nao_Especial, "");
            Assert.IsTrue(d.Valid);
        }
    }
}
