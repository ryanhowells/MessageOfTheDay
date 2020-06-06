using FluentAssert;
using MessageOfTheDay.Services;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using Xunit;

namespace MessageOfTheDayTests.Services
{
    public class MessageServiceTests
    {
        public class GivenDataIsValid_WhenFormattingMessagePath
        {
            [Theory]
            [ClassData(typeof(TestData))]
            public void ThenTheCorrectFormatIsReturned(string expectedOutput, string languageCode, DayOfWeek dayOfWeek)
            {
                var mockEnvironment = new Mock<IWebHostEnvironment>();
                mockEnvironment.Setup(x => x.WebRootPath).Returns("/root/path");
                var messageService = new MessageService(mockEnvironment.Object);
                string result = messageService.FormatPath(languageCode, dayOfWeek);
                result.ShouldBeEqualTo(expectedOutput);
            }

            public class TestData : TheoryData<string, string, DayOfWeek>
            {
                public TestData()
                {
                    Add("/root/path/messages/en/Monday.txt", "en", DayOfWeek.Monday);
                    Add("/root/path/messages/en/Tuesday.txt", null, DayOfWeek.Tuesday);
                    Add("/root/path/messages/de/Wednesday.txt", "de", DayOfWeek.Wednesday);
                    Add("/root/path/messages/fr/Thursday.txt", "fr", DayOfWeek.Thursday);
                }
            }
        }
    }
}
