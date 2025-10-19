using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Genre
{
    public class ServiceResponse
    {
        public string Message { get; set; } = string.Empty;

        public bool IsSuccess { get; set; } = true;

        public object? Payload { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
