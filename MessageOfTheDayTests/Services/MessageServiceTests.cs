using FluentAssert;
using MessageOfTheDay.Services;
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
            public void ThenTheCorrectFormatIsReturned(string expectedOutput, string rootPath, string languageCode, DayOfWeek dayOfWeek)
            {
                var messageService = new MessageService();
                string result = messageService.FormatPath(rootPath, languageCode, dayOfWeek);
                result.ShouldBeEqualTo(expectedOutput);
            }

            public class TestData : TheoryData<string, string, string, DayOfWeek>
            {
                public TestData()
                {
                    Add("/root/path/messages/en/Monday.txt", "/root/path", "en", DayOfWeek.Monday);
                    Add("/root/path/messages/en/Tuesday.txt", "/root/path", null, DayOfWeek.Tuesday);
                    Add("/root/path/messages/de/Wednesday.txt", "/root/path", "de", DayOfWeek.Wednesday);
                    Add("/root/path/messages/fr/Thursday.txt", "/root/path", "fr", DayOfWeek.Thursday);
                }
            }
        }
    }
}
