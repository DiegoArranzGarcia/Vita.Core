namespace Vita.Common;

public readonly record struct DateTimeInterval
{
    public DateTimeOffset Start { get; init; }
    public DateTimeOffset End { get; init; }

    public DateTimeInterval(DateTimeOffset start, DateTimeOffset end)
    {
        if (end < start)
            throw new ArgumentOutOfRangeException(nameof(end));

        Start = start;
        End = end;
    }
}