using Dmed.Auxiliares;
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
    public class RPPSS : Notifiable, IEntidade
    {
        public RPPSS(string cpf, string nome, decimal valorPago)
        {
            Cpf = cpf;
            Nome = nome;
            ValorPago = valorPago;

            var documentoVO = new DocumentoVO(cpf: cpf);
            var nomeVO = new NomeVO(nome);

            AddNotifications(documentoVO, nomeVO);
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(valorPago, 0, "RPPSS.ValorPago", "Valor pago deverá ser superior a zero."));
        }

        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public decimal ValorPago { get; private set; }

        public Result<string> GerarRegistro()
        {
            var identificador = "RPPSS";
            var cpf = this.Cpf;
            var nome = Auxiliar.PrepararCampo(this.Nome);
            var valorPago = Auxiliar.PrepararCampo(this.ValorPago);
            
            var arquivo = new StringBuilder();
            arquivo.AppendFormat("{0}|", identificador);
            arquivo.AppendFormat("{0}|", cpf);
            arquivo.AppendFormat("{0}|", nome);
            arquivo.AppendFormat("{0}|", valorPago);

            return Results.Ok(arquivo.ToString());
        }

    }
}
