//using Application.Interfaces;
//using Microsoft.AspNetCore.Diagnostics;
//using System.Net;
//using Microsoft.AspNetCore.Http;
//using Domain.Dto;

//namespace Api.Extentions
//{
//    public static class MiddlewareException
//    {
//        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
//        {
//            app.UseExceptionHandler(appError => {

//                appError.Run(async context =>
//                {
//                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                    context.Response.ContentType = "application/json";
//                    logger.LogError($"somthing went wrong : {context}");
//                    logger.LogError($"somthing went wrong : {context.Response}");
//                    logger.LogError($"somthing went wrong : {context.Response.StatusCode}");
//                    logger.LogError($"somthing went wrong : {appError}");
//                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//                    if (contextFeature != null)
//                    {
//                        logger.LogError($"somthing went wrong : {contextFeature.Error}");
//                        logger.LogError($"somthing went wrong : {contextFeature}");

//                        await context.Response.WriteAsync(new ResponseResult()
//                        {
//                            IsSuccess = false,
//                            Message = "Internal Server Error",
//                            Obj = context.Response.StatusCode

//                        }.ToString());
//                    }
//                });
//            });
//        }
//    }

//}
