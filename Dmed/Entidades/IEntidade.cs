using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmed.Entidades
{
    public interface IEntidade
    {
        Result<string> GerarRegistro();
    }
}
