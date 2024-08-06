using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using YuriiPasternak.SimpleRealEstate.Application.Common.Exceptions;

namespace YuriiPasternak.SimpleRealEstate.WebAPI.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.ContentType = "application/json";

                    var errorDetails = new string[] { };

                    switch (contextFeature.Error)
                    {
                        case NotFoundException:
                            {
                                var errorResponse = new
                                {
                                    statusCode = context.Response.StatusCode,
                                    message = contextFeature.Error.GetBaseException().Message,
                                };
                                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                                break;
                            }
                        case BadRequestException:
                            {
                                var exception = (BadRequestException)contextFeature.Error;
                                var errorResponse = new
                                {
                                    statusCode = context.Response.StatusCode,
                                    message = contextFeature.Error.GetBaseException().Message,
                                    errorDetails = exception.Errors
                                };
                                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                                break;
                            }

                        case UnauthorizedAccessException:
                            {
                                var errorResponse = new
                                {
                                    statusCode = context.Response.StatusCode,
                                    message = contextFeature.Error.GetBaseException().Message,
                                };
                                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                                break;
                            }


                        case OperationCanceledException:
                            {
                                var errorResponse = new
                                {
                                    statusCode = context.Response.StatusCode,
                                    message = contextFeature.Error.GetBaseException().Message,
                                };
                                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                                break;
                            }

                        case SaveChangesFailedException:
                            {
                                var errorResponse = new
                                {
                                    statusCode = context.Response.StatusCode,
                                    message = contextFeature.Error.GetBaseException().Message,
                                };
                                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                                break;
                            }

                        default:
                            {
                                var errorResponse = new
                                {
                                    statusCode = context.Response.StatusCode,
                                    message = contextFeature.Error.GetBaseException().Message,
                                };

                                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                                break;
                            }
                    }
                });
            });
        }
    }
}
