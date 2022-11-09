using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.SeedWorks
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(bool isSuccess, int statusCode, string message) : base(isSuccess, statusCode, message)
        {
        }

        public ApiSuccessResult(bool isSuccess, string message , int statusCode, T resultObj) : base(isSuccess, message, statusCode, resultObj)
        {
        }
    }
}
