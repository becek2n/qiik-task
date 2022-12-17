using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QIIK.DTO
{
    public class ResultDTO<T>
    {
        public ResultDTO()
        {

        }
        public ResultDTO(bool IsSuccess)
        {
            this.ResponseCode = (IsSuccess) ? "200" : "400";
            this.ResponseMessage = (IsSuccess) ? "success" : "failed";
        }

        public ResultDTO<T> SetSuccess(string message, T value = default(T))
        {
            this.ResponseCode = "200";
            this.ResponseMessage = message != null ? message : "success";
            this.ResponseData = value;
            return this;
        }

        public ResultDTO<T> SetFailed(string message, string statusCode = "400", T value = default(T), Exception Ex = null)
        {
            this.ResponseCode = "400";
            this.ResponseMessage = message != null ? message.Replace("'", "") : "failed";
            this.ResponseData = value;
            return this;
        }

        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public T ResponseData { get; set; }
    }

}

