using Xunit.Sdk;

namespace Vita.Core.UnitTests.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoMoqMemberDataAttribute : CompositeDataAttribute
{
    public AutoMoqMemberDataAttribute(string memberName, Type MemberType) : base(new DataAttribute[]
        {
            new MemberDataAttribute(memberName)
            {
                MemberType = MemberType,
            },
            new AutoMoqDataAttribute()
        })
    {
    }
}
