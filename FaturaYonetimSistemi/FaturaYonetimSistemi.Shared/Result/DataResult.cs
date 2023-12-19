using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Result
{
    public class DataResult<T>: IDataResult<T>,IResult where T : class, new()
    {



        public DataResult(T data)
        {
            Data = data;
        }

        public DataResult(T data,ResultStatus statu)
        {
            Data = data;
            Statu = statu;
        }

        public DataResult(T data, ResultStatus statu,string message)
        {
            Data = data;
            Statu = statu;
            Message = message;
        }


        public T Data { get; }

        public string Message { get; }

        public ResultStatus Statu { get; }


    }
}
