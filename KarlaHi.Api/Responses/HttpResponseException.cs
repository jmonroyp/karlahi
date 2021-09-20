using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace KarlaHi.Api.Responses
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}