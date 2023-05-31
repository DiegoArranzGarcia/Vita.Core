using Vita.Goals.UnitTests.Attributes;

namespace Vita.Common.Tests.Attributes;

public sealed class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] objects)
        : base(new AutoMoqDataAttribute(), objects)
    {
    }
}
