namespace Opuspac.Api.Utilities;

public static class HeaderHelper
{
    public static string? GetRemoteIpAddress(this HttpRequest httpRequest)
    {
        var forwardedIp = GetForwardedIpAddress(httpRequest.Headers["forwarded"]);
        return forwardedIp ?? httpRequest.HttpContext.Connection?.RemoteIpAddress?.ToString().Replace("::ffff:", "");
    }

    // Funcao especifica para tratar o header "forwarded"
    // O alguns gateways usa x-forwarded-for, mas estou usando api gateway da aws que usa rfc7239
    private static string? GetForwardedIpAddress(string? forwared)
    {
        if (forwared == null) return null;

        var forIp = forwared.Split(";").Where(h => h.Contains("for")).First();

        if (forIp == null) return null;

        return forIp[4..];
    }
}
