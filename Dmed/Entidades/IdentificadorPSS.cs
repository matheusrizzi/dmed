using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.Entidades
{
    public class IdentificadorPSS : IEntidade
    {
        public Result<string> GerarRegistro()
        {
            return Results.Ok("PSS|");
        }
    }
}
