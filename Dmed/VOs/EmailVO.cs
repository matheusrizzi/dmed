using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.VOs
{
    public class EmailVO:Notifiable
    {
        public EmailVO(string email)
        {
            Email = email;
            AddNotifications(new Contract().Requires().IsEmail(email, "EmailVO.Email", "Email não informado ou invalido."));
        }

        public string Email { get; private set; }
    }
}
