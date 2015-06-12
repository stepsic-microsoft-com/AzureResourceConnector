using Hyak.Common;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace AzureResourceConnector.Filters
{
    public class CloudExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is CloudException)
            {
                var except = (CloudException)context.Exception;

                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(except.Response.Content),
                    StatusCode = except.Response.StatusCode,
                    ReasonPhrase = except.Response.ReasonPhrase
                };

                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                context.Response = resp;
            }
            else if (context.Exception is AdalServiceException)
            {
                var except = (AdalServiceException)context.Exception;

                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(except.Message),
                    StatusCode = (HttpStatusCode)except.StatusCode
                };

                context.Response = resp;
            }
            else if (context.Exception is InvalidOperationException)
            {
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(context.Exception.Message),
                    StatusCode = HttpStatusCode.BadRequest
                };

                context.Response = resp;
            }
        }
    }
}