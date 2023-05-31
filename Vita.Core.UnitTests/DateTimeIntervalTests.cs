using FluentAssertions;
using Vita.Common;
using Vita.Core.UnitTests.Attributes;

namespace Vita.Core.UnitTests
{
    public class DateTimeIntervalTests
    {
        [Theory]
        [AutoMoqData]
        public void GivenEndDateAfterStartDate_WhenCreatingDateTimeInternal_ThenCreatesItCorrectly(DateTime start)
        {
            DateTime end = start.AddDays(7);

            DateTimeInterval interval = new(start, end);

            interval.Start.Should().Be(start);
            interval.End.Should().Be(end);
        }

        [Theory]
        [AutoMoqData]
        public void GivenSameDate_WhenCreatingDateTimeInterval_ThenCreatesItCorrectly(DateTime date)
        {
            DateTimeInterval interval = new(date, date);

            interval.Start.Should().Be(date);
            interval.End.Should().Be(date);
        }

        [Theory]
        [AutoMoqData]
        public void GivenEndDateBeforeStartDate_WhenCreatingDateTimeInterval_ThenThrowsArgumentOutOfRangeException(DateTime start)
        {
            DateTime end = start.AddMicroseconds(-1);

            Action act = () => _ = new DateTimeInterval(start, end);

            act.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Theory]
        [AutoMoqData]
        public void GivenTwoDifferentDateTimeInterval_WhenComparingIfEquals_ThenReturnsFalse(DateTimeInterval source, DateTimeInterval destination)
        {
            bool comparisonResult = source == destination;

            comparisonResult.Should().BeFalse();
        }

        [Theory]
        [AutoMoqData]
        public void GivenTwoEqualsInterval_WhenComparingIfEquals_ThenReturnsTrue(DateTimeInterval source)
        {
            DateTimeInterval destination = new(source.Start, source.End);

            bool comparisonResult = source == destination;

            comparisonResult.Should().BeTrue();
        }
    }
}