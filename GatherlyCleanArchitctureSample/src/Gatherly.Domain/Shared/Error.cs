namespace Gatherly.Domain.Shared;

public class Error : IEquatable<Error>
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public string Code { get; set; }
    public string Message { get; set; }

    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error a, Error b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Error a, Error b) => !(a == b);

    public override bool Equals(object? obj) => obj is Error error && Equals(error);

    public override string ToString() => Code;

    public override int GetHashCode() => HashCode.Combine(Code, Message);

    bool IEquatable<Error>.Equals(Error? other)
    {
        if (other is null)
            return false;

        return (Message == other.Message && Code == other.Code);
    }
}
