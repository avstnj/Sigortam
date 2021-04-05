using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigortam.WebUI.ApiHelpers
{
    public class ApiResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }

    public class ApiResult<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
