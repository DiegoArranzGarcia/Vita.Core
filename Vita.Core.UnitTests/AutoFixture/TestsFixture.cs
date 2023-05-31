using AutoFixture.AutoMoq;
using Vita.Goals.UnitTests.AutoFixture.SpecimenBuilders;

namespace Vita.Core.UnitTests.AutoFixture;
public static class TestsFixture
{
    public static IFixture CreateFixture()
    {
        Fixture fixture = new();

        fixture.Customize(new AutoMoqCustomization());

        fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 1));

        fixture.Customizations.Add(new DateTimeIntervalSpecimenBuilder());

        return fixture;
    }
}
