using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Models
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public bool Success { get; set; }
        public Error? Error { get; set; }

        public Result(T data)
        {
                Value = data;
                Success = true;
                Error = null;
        }

        public Result(Error error)
        {
            Value = default;
            Success = false;
            Error = error;
        }
    }
}
