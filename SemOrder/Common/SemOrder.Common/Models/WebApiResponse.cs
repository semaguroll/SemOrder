using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Common.Models
{
    public class WebApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }
        public T ResultData { get; set; }

        public WebApiResponse()
        {

        }
        public WebApiResponse(bool isSuccess, string resultMessage)
        {
            IsSuccess = isSuccess;
            ResultMessage = resultMessage;
        }
        public WebApiResponse(bool isSuccess, string resultMessage, T resultData)
              : this(isSuccess, resultMessage)
        {
            ResultData = resultData;
        }
    }
}
