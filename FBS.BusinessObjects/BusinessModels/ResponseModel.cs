using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.BusinessObjects.BusinessModels
{
    public class ResponseModel(object? result, string? message, bool isSucceed, int statusCode)
    {
        public object? Result { get; set; } = result;
        public string? Message { get; set; } = message;
        public bool IsSucceed { get; set; } = isSucceed;
        public int StatusCode { get; set; } = statusCode;
    }
}
