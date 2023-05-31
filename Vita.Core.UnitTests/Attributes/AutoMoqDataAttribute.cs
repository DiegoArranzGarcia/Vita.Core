using Vita.Core.UnitTests.AutoFixture;

namespace Vita.Core.UnitTests.Attributes;
public sealed class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute() : base(TestsFixture.CreateFixture)
    {

    }
}
