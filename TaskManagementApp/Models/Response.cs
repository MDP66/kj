using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaskManagementApp.Models
{
    public class Response<T> where T : class
    {
        public Response(HttpStatusCode pStauscode, T pResponse)
        {
            StatusCode = pStauscode;
            Payload = pResponse;
        }
        public Response(HttpStatusCode pStauscode, string pErrorMessage, T pResponse)
        {
            ErrorMessage = pErrorMessage;
            StatusCode = pStauscode;
            Payload = pResponse;
        }
        private HttpStatusCode StatusCode { get; set; }
        private string? ErrorMessage { get; set;}
        private T? Payload {get; set;}    
    }
}