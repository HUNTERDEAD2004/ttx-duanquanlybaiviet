using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Response
{
    public class ResponseDTO<T>
    {
        public T DataResponse { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

        public ResponseDTO()
        {
            DataResponse = default;
            Status = StatusCodes.Status200OK; // Mặc định là 200 OK
            Message = "Success"; // Thông điệp mặc định
        }

        public ResponseDTO(T dataResponse, int status, string message)
        {
            DataResponse = dataResponse;
            Status = status;
            Message = message;
        }
    }
}
