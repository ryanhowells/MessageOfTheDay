using FluentAssert;
using MessageOfTheDay.Services;
using Xunit;

namespace MessageOfTheDayTests.Services
{
    public class ImageServiceTests
    {
        public class GivenDayOfWeekIsValid_WhenFormattingImagePath
        {
            [Theory]
            [ClassData(typeof(TestData))]
            public void ThenTheCorrectFormatIsReturned(string expectedOutput, string dayOfWeek)
            {
                var imageService = new ImageService();
                string result = imageService.Format(dayOfWeek);
                result.ShouldBeEqualTo(expectedOutput);
            }

            public class TestData : TheoryData<string, string>
            {
                public TestData()
                {
                    Add("/images/monday.jpg", "monday");
                    Add("/images/tuesday.jpg", "tuesday");
                    Add("/images/wednesday.jpg", "wednesday");
                    Add("/images/thursday.jpg", "thursday");
                    Add("/images/friday.jpg", "friday");
                    Add("/images/saturday.jpg", "saturday");
                    Add("/images/sunday.jpg", "sunday");
                }
            }
        }
    }
}
