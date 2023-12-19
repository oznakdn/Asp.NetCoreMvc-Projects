using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Result
{
    public class Result:IResult
    {

        public string Message { get; }
        public ResultStatus Statu { get; }

        public Result(string message,ResultStatus statu)
        {
            Message = message;
            Statu = statu;
        }

        public Result(ResultStatus statu)
        {
            Statu = statu;
        }


    }
}
