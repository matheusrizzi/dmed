using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.VOs
{
    public class NomeVO:Notifiable
    {
        public NomeVO(string nome)
        {
            Nome = nome;
            AddNotifications(new Contract().Requires().IsNotNullOrEmpty(nome, "Nome.NomePessoa", "Nome inválido ou não informado."));
        }

        public string Nome { get; private set; }
    }
}
