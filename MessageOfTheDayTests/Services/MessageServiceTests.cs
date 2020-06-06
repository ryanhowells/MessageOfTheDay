using FluentAssert;
using MessageOfTheDay.Services;
using Xunit;

namespace MessageOfTheDayTests.Services
{
    public class MessageServiceTests
    {
        public class GivenDataIsValid_WhenFormattingMessagePath
        {
            [Theory]
            [ClassData(typeof(TestData))]
            public void ThenTheCorrectFormatIsReturned(string expectedOutput, string rootPath, string languageCode, string dayOfWeek)
            {
                var messageService = new MessageService();
                string result = messageService.FormatPath(rootPath, languageCode, dayOfWeek);
                result.ShouldBeEqualTo(expectedOutput);
            }

            public class TestData : TheoryData<string, string, string, string>
            {
                public TestData()
                {
                    Add("/root/path/messages/en/monday.txt", "/root/path", "en", "monday");
                    Add("/root/path/messages/en/tuesday.txt", "/root/path", null, "tuesday");
                    Add("/root/path/messages/de/wednesday.txt", "/root/path", "de", "wednesday");
                    Add("/root/path/messages/fr/thursday.txt", "/root/path", "fr", "thursday");
                }
            }
        }
    }
}
