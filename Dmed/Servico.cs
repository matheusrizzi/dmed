using Dmed.Entidades;
using FluentResults;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed
{
    public interface IServico
    {
        Result<string> ObterDmed(); 
    }

    public class Servico:Notifiable
    {
        public Servico(Declaracao declaracao, 
                       Responsavel responsavel, 
                       IEnumerable<RPPSS> listaRPPSS, 
                       DeclarantePJ declarantePJ)
        {
            Declaracao = declaracao;
            Responsavel = responsavel;
            ListaRPPSS = listaRPPSS;
            DeclarantePJ = declarantePJ;

            AddNotifications(responsavel, declarantePJ, declaracao);

            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(null, ListaRPPSS, "Servico.ListaRPPSS", "Informe a lista RPPSS válida.")
                );
        }
        public Responsavel Responsavel { get; private set; }
        public IEnumerable<RPPSS> ListaRPPSS { get; private set; }
        public DeclarantePJ DeclarantePJ { get; private set; }
        public Declaracao Declaracao { get; private set; }

        public Result<string> ObterDmed()
        {
            if (this.Invalid)
                return Results.Fail<string>(RetornarStringErros());

            var dmed = new StringBuilder();

            dmed.AppendFormat(this.Declaracao.GerarRegistro().Value + "{0}", Environment.NewLine);
            dmed.AppendFormat(this.Responsavel.GerarRegistro().Value + "{0}", Environment.NewLine);
            dmed.AppendFormat(this.DeclarantePJ.GerarRegistro().Value + "{0}", Environment.NewLine);
            dmed.AppendFormat(new IdentificadorPSS().GerarRegistro().Value + "{0}", Environment.NewLine);

            this.ListaRPPSS.ToList().ForEach(x => dmed.AppendLine(x.GerarRegistro().Value));

            dmed.AppendLine("FIMDmed|");

            return Results.Ok(dmed.ToString());
        }

        private string RetornarStringErros()
        {
            var sb = new StringBuilder();
            this.Notifications.ToList().ForEach(x => sb.AppendLine(x.Message));
            return sb.ToString();
        }
    }


}
