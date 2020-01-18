using Microsoft.AspNetCore.Http;
using PlanNeuro.API.ResponseHelpers;
using PlanNeuro.Domain.Enums;
using PlanNeuro.Domain.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;

namespace PlanNeuro.API.Middlewares
{
    public class ValidationExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if (context.Response.StatusCode == 403)
                {
                    ErrorResposeWriter.WriteExceptionResponse(context, "You don't have permission");
                }
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private void HandleException(HttpContext context, Exception ex)
        {
            string exceptionResponse;
            if (ex.GetType() == typeof(DALNotFoundException))
            {
                exceptionResponse = ResponseCreator.CreateBadResponse((int)HttpStatusCode.BadRequest,
                                                                      (int)ErrorCode.DALNotFoundError,
                                                                       ex.Message);
            }
            else if (ex.GetType() == typeof(DbException))
            {
                exceptionResponse = ResponseCreator.CreateBadResponse((int)HttpStatusCode.BadRequest,
                                                                      (int)ErrorCode.DBError,
                                                                       ex.Message);
            }
            else if (ex.GetType() == typeof(PermissionException))
            {
                exceptionResponse = ResponseCreator.CreateBadResponse((int)HttpStatusCode.Forbidden,
                                                                      (int)ErrorCode.PermissionError,
                                                                       ex.Message);
            }
            else if (ex.GetType() == typeof(ValidationException))
            {
                exceptionResponse = ResponseCreator.CreateBadResponse((int)HttpStatusCode.BadRequest,
                                                                      (int)ErrorCode.ValidationError,
                                                                       ex.Message);
            }
            else
            {
                exceptionResponse = ResponseCreator.CreateBadResponse((int)HttpStatusCode.InternalServerError,
                                                                      (int)ErrorCode.ServerError,
                                                                        "server error");
            }
            ErrorResposeWriter.WriteExceptionResponse(context, exceptionResponse);
        }
    }
}
