using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.VOs
{
    public class DocumentoVO:Notifiable
    {
        public DocumentoVO(string cpf="", string cnpj="")
        {
            Cpf = cpf;
            Cnpj = cnpj;

            if (string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(cnpj))
                AddNotification("Documento.Cpf e Documento.Cnpj", "Informe um cpf ou um cnpj.");

            if (!string.IsNullOrEmpty(cpf) && !string.IsNullOrEmpty(cnpj))
                AddNotification("Documento.cpf","Uma entidade terá cpf ou cnpj, nunca as duas!");

            if (!string.IsNullOrEmpty(cpf))
                AddNotifications(new Contract().Requires().IsCpf(cpf, "Documento.Cpf", "Cpf inválido."));

            if (!string.IsNullOrEmpty(cnpj))
                AddNotifications(new Contract().Requires().IsCnpj(cnpj, "Documento,Cnpj", "Cnpj inválido."));
        }

        public string Cpf { get; private set; }
        public string Cnpj { get; private set; }
    }
}
