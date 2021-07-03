using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Domain.Model
{
    public class ServiceResponse
    {

        public static ServiceResponse SuccessResponse() => SuccessResponse(null);
        public static ServiceResponse SuccessResponse(object payload) => new ServiceResponse { success = true, data = payload };
        public static ServiceResponse SuccessResponse(string message, object payload) => new ServiceResponse { success = true, data = payload, msg = message };
        public static ServiceResponse ErrorResponse(string message) => new ServiceResponse { msg = message, success = false, data = null };
        public static ServiceResponse ErrorResponse(Exception exception) => ErrorResponse(exception.Message);
        public object data { get; set; }
        public string msg { get; set; }
        public bool success { get; set; }
        public List<ErrorMessage> errorlst { get; set; }
    }

    public class ErrorMessage
    {
        public string error { get; set; }
        public string value { get; set; }
    }
}
