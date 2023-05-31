using Vita.Goals.UnitTests.AutoFixture;

namespace Vita.Common.Tests.Attributes;
public sealed class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute() : base(TestsFixture.CreateFixture)
    {

    }
}
