﻿using API.Errors;
using System.Net;
using System.Text.Json;

namespace API.Middlware;
public class ExceptionMiddleware(IHostEnvironment env, RequestDelegate next) {
    public async Task InvokeAsync(HttpContext context) {
        try {
            await next(context);
        }
        catch (Exception ex) {
            await HandleExceptionAsync(context, ex, env);
        }
        }

    private static Task HandleExceptionAsync (HttpContext context, Exception ex, IHostEnvironment env) {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        string Message = env.IsDevelopment() ? ex.Message : "Internal server error";
        var response = new ApiErrorResponse(context.Response.StatusCode, ex.Message, Message);
        
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(response, options);
        return context.Response.WriteAsync(json);

    }
}

