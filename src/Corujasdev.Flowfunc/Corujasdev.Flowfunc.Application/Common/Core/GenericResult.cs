﻿using Flunt.Notifications;

namespace Corujasdev.Flowfunc.Application.Common.Core;

public class GenericResult : Notifiable<Notification>
{
    public GenericResult()
    {

    }

    public GenericResult(bool success, string message, object data, int statusCode)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
        Data = data;
    }


    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; } = null;
}