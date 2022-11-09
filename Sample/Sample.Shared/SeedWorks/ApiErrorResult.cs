using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.SeedWorks
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public List<string> Errors { get; set; }    
        public ApiErrorResult(bool isSuccess, int statusCode,string message) : base(false, statusCode, message)
        {
        }
        public ApiErrorResult(bool isSuccess, int statusCode,List<string> errors) : base(false,statusCode)
        {
            Errors = errors;
        }

    }
}
