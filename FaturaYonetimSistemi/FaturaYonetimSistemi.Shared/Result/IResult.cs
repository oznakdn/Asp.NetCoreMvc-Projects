using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Result
{
    public interface IResult
    {
        string Message { get; }
        ResultStatus Statu { get; }
    }
}
