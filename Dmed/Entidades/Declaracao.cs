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
    public class Declaracao : Notifiable, IEntidade
    {
        public Declaracao( 
                          int anoReferencia, 
                          int anoCalendario, 
                          string numeroRecibo, 
                          string leiaute,
                          bool retificadora = false)
        {
            IdentificadorRegistro = "Dmed";
            AnoReferencia = anoReferencia;
            AnoCalendario = anoCalendario;
            NumeroRecibo = numeroRecibo;
            Leiaute = leiaute;
            Retificadora = retificadora;

            if (retificadora)
                if (string.IsNullOrEmpty(numeroRecibo))
                    AddNotification("Declaracao.NumeroRecibo", "Numero do recibo deve ser informado para declaração retificadora.");

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(AnoReferencia > 0, "Declaracao.AnoReferencia", "Ano de referência deve ser maior que zero.")
                .IsTrue(AnoCalendario > 0, "Declaracao.AnoCalendario", "Ano calendário deve ser maior que zero.")
                .IsTrue(anoCalendario <= anoReferencia, "Declaracao.AnoCalendario", "Ano calendário não pode ser maior que o ano de referência.")
                );
        }

        public string IdentificadorRegistro { get; private set; }
        public int AnoReferencia { get; private set; }
        public int AnoCalendario { get; private set; }
        public string NumeroRecibo { get; private set; }
        public string Leiaute { get; private set; }
        public bool Retificadora { get; private set; }

        public Result<string> GerarRegistro()
        {
            //var leiaute = "P8915U";
            var declaracao_retificadora = this.Retificadora ? "S":"N";
            var registro = new StringBuilder();

            registro.AppendFormat("{0}|", this.IdentificadorRegistro);
            registro.AppendFormat("{0}|", this.AnoReferencia);
            registro.AppendFormat("{0}|", this.AnoCalendario);
            registro.AppendFormat("{0}|", declaracao_retificadora);
            registro.AppendFormat("{0}|", this.NumeroRecibo);
            registro.AppendFormat("{0}|", this.Leiaute);

            return Results.Ok(registro.ToString());
        }
    }
}
