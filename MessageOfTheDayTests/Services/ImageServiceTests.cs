using FluentAssert;
using MessageOfTheDay.Services;
using System;
using Xunit;

namespace MessageOfTheDayTests.Services
{
    public class ImageServiceTests
    {
        public class GivenDayOfWeekIsValid_WhenFormattingImagePath
        {
            [Theory]
            [ClassData(typeof(TestData))]
            public void ThenTheCorrectFormatIsReturned(string expectedOutput, DayOfWeek dayOfWeek)
            {
                var imageService = new ImageService();
                string result = imageService.Format(dayOfWeek);
                result.ShouldBeEqualTo(expectedOutput);
            }

            public class TestData : TheoryData<string, DayOfWeek>
            {
                public TestData()
                {
                    Add("/images/Monday.jpg", DayOfWeek.Monday);
                    Add("/images/Tuesday.jpg", DayOfWeek.Tuesday);
                    Add("/images/Wednesday.jpg", DayOfWeek.Wednesday);
                    Add("/images/Thursday.jpg", DayOfWeek.Thursday);
                    Add("/images/Friday.jpg", DayOfWeek.Friday);
                    Add("/images/Saturday.jpg", DayOfWeek.Saturday);
                    Add("/images/Sunday.jpg", DayOfWeek.Sunday);
                }
            }
        }
    }
}
