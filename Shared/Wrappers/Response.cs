using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Wrappers
{
    public class Response
    {
        public Status StatusCode { get; set; }
        public string? Message { get; set; }
        public object? ResultData { get; set; }
    }
    public enum Status
    {
        Success = HttpStatusCode.OK,
        Failure = HttpStatusCode.InternalServerError,
        Restricted = HttpStatusCode.Forbidden,
        PartialContent = HttpStatusCode.PartialContent,
        Conflict = HttpStatusCode.Conflict,
        BadRequest = HttpStatusCode.BadRequest,
        NotModified = HttpStatusCode.NotModified,
        Duplicate = HttpStatusCode.Conflict,
        UnAuthorized = HttpStatusCode.Unauthorized,
        NotFound = HttpStatusCode.NotFound
    }


}
