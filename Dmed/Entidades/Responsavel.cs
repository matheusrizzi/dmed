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
    public class Responsavel: Notifiable, IEntidade
    {
        public Responsavel(string cpf, string nome, string ddd, string telefone, string ramal, string fax, string email)
        {
            this.DDD = ddd;
            this.Telefone = telefone;
            this.Ramal = ramal;
            this.Fax = fax;
            this.Email = email;
            this.Nome = nome;
            this.Cpf = cpf;

            var documentoVO = new DocumentoVO(cpf: cpf);
            var nomeVO = new NomeVO(nome);
            var emailVO = new EmailVO(email);

            AddNotifications(documentoVO, nomeVO, emailVO);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(ddd, "Responsavel.DDD","Campo DDD do responsável é obrigatório.")
                .IsNotNullOrEmpty(telefone, "Responsavel.Telefone", "Campo telefone do responsável é obrigatório")
                );
        }

        public string Cpf { get; set; }
        public string Nome { get; private set; }
        public string DDD { get; private set; }
        public string Telefone { get; private set; }
        public string Ramal { get; private set; }
        public string Fax { get; private set; }
        public string Email { get; private set; }

        public Result<string> GerarRegistro()
        {
            var arquivo = new StringBuilder();

            arquivo.AppendFormat("{0}|", "RESPO");
            arquivo.AppendFormat("{0}|", this.Cpf);
            arquivo.AppendFormat("{0}|", this.Nome);
            arquivo.AppendFormat("{0}|", this.DDD);
            arquivo.AppendFormat("{0}|", this.Telefone);
            arquivo.AppendFormat("{0}|", this.Ramal);
            arquivo.AppendFormat("{0}|", this.Fax);
            arquivo.AppendFormat("{0}|", this.Email);

            return Results.Ok(arquivo.ToString());
        }
    }
}
