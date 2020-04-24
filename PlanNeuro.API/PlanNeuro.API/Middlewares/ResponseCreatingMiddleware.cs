using Microsoft.AspNetCore.Http;
using PlanNeuro.API.ResponseHelpers;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace PlanNeuro.API.Middlewares
{
    public class ResponseCreatingMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseCreatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //save original readable stream in order  to write response to it
            var originalBodyStream = context.Response.Body;
            try
            {
                using (var responseBody = new MemoryStream())
                {
                    //make the response.body stream readable and empty 
                    context.Response.Body = responseBody;

                    await _next(context);

                    //write the response made to the stream
                    using (var streamWriter = new StreamWriter(originalBodyStream))
                    {
                        var response = await ResponseCreator.CreateSuccessResponseAsync(context.Response, (int)HttpStatusCode.OK);

                        streamWriter.Write(response);
                    }
                }
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }
}
