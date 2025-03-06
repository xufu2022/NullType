using System;

namespace NullWithWebAPI.Server.Model;
public class ErrorViewModel
{
    public required string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}