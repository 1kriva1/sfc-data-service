namespace SFC.Data.Application.Common.Exceptions;
public class AuthorizationException : Exception
{
    public AuthorizationException(string message) : base(message) { }
}
