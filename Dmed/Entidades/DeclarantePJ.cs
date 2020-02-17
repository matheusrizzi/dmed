using Dmed.Enums;
using Dmed.VOs;
using FluentResults;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.Entidades
{
    public class DeclarantePJ : Notifiable, IEntidade
    {
        public DeclarantePJ(string cnpj, string razaoSocial, ETipoDeclarante tipoDeclarante, 
                          string registroANS, string cNES, string cpfResponsavel, 
                          ESituacaoDeclaracao indicadorSituacao, string dataEvento)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            TipoDeclarante = tipoDeclarante;
            RegistroANS = registroANS;
            CNES = cNES;
            CpfResponsavel = cpfResponsavel;
            IndicadorSituacao = indicadorSituacao;
            DataEvento = dataEvento;

            if (string.IsNullOrEmpty(registroANS) && tipoDeclarante != ETipoDeclarante.Prestador_Servico_Saude)
                AddNotification("Declarante.RegistroANS","Registro ANS deve ser informado para declarante tipo 2 ou 3.");

            if (string.IsNullOrEmpty(dataEvento) && indicadorSituacao != ESituacaoDeclaracao.Situacao_Nao_Especial)
                AddNotification("Declarante.DataEvento", "Data do evento deve ser preenchida para situação especial!");

            var cnpjVO = new DocumentoVO(cnpj: cnpj);
            var cpfVO = new DocumentoVO(cpf: cpfResponsavel);

            AddNotifications(cnpjVO, cpfVO);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(razaoSocial, "Declarante.RazaoSocial", "Razão Social do Declarante não informada ou invalida.")
                );
        }

        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public ETipoDeclarante TipoDeclarante { get; private set; }
        public string RegistroANS { get; private set; }
        public string CNES { get; private set; }
        public string CpfResponsavel { get; private set; }
        public ESituacaoDeclaracao IndicadorSituacao { get; private set; }
        public string DataEvento { get; private set; }

        public Result<string> GerarRegistro()
        {
            var arquivo = new StringBuilder();

            var campo00 = "DECPJ";                      //identificador
            var campo01 = this.Cnpj;                    //cnpj
            var campo02 = this.RazaoSocial;             //Razão Social
            var campo03 = (int)this.TipoDeclarante;     //1=Prestador de serviço de saúde - Tipo do declarante
            var campo04 = this.RegistroANS;             //Registro ANS
            var campo05 = this.CNES;                    //CNES
            var campo06 = this.CpfResponsavel;          //CPF Responsavel perante cnpj
            var campo07 = this.IndicadorSituacao == ESituacaoDeclaracao.Situacao_Especial ? "S" : "N";       //Indicador de Situacao
            var campo08 = this.DataEvento;              //Data do evento

            arquivo.AppendFormat("{0}|", campo00);
            arquivo.AppendFormat("{0}|", campo01);
            arquivo.AppendFormat("{0}|", campo02);
            arquivo.AppendFormat("{0}|", campo03);
            arquivo.AppendFormat("{0}|", campo04);
            arquivo.AppendFormat("{0}|", campo05);
            arquivo.AppendFormat("{0}|", campo06);
            arquivo.AppendFormat("{0}|", campo07);
            arquivo.AppendFormat("{0}|", campo08);

            return Results.Ok(arquivo.ToString());
        }
    }
}
