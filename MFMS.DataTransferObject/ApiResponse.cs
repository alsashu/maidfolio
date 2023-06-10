using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.DataTransferObject
{
    public class ApiResponse
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public object? Payload { get; set; }
    }
    public enum ResponseType
    {
        Success,
        NotFound,
        Failure
    }
}

