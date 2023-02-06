using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.SeedWorks
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T ResultObj { get; set; }
        public ApiResult(bool isSuccess, string message, int statusCode, T resultObj)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
            ResultObj = resultObj;
        }
        public ApiResult(bool isSuccess,  int statusCode,string message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }
    }
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
       
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public ApiResult(bool isSuccess, string message, int statusCode)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
        }
        public ApiResult(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
        public ApiResult() { }
    }
}
