using FluentAssert;
using MessageOfTheDay;
using MessageOfTheDay.Constants;
using MessageOfTheDay.Interfaces;
using MessageOfTheDay.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Xunit;
using Moq;

namespace MessageOfTheDayTests.Pages
{
    public class IndexTests
    {
        public class OnPost
        {
            private readonly Mock<IWebHostEnvironment> _envMock;
            private readonly Mock<IMessageService> _messageServiceMock;
            private readonly Mock<IImageService> _imageServiceMock;

            public OnPost()
            {
                _envMock = new Mock<IWebHostEnvironment>();
                _messageServiceMock = new Mock<IMessageService>();
                _imageServiceMock = new Mock<IImageService>();
            }

            public class GivenLanguageInCache_WhenPostingNewLanguageToMessageOfTheDay : OnPost
            {
                private readonly IMemoryCache _cache;
                private readonly IndexModel _indexModel;
                private readonly string _cacheKey;

                public GivenLanguageInCache_WhenPostingNewLanguageToMessageOfTheDay()
                {
                    _cacheKey = CacheKeys.Language;
                    _cache = new MemoryCache(new MemoryCacheOptions());
                    _cache.Set(_cacheKey, LanguageCodes.German);

                    _indexModel = new IndexModel(_envMock.Object, _messageServiceMock.Object, _imageServiceMock.Object, _cache);
                }

                [Fact]
                public void ThenTheCacheIsUpdated()
                {
                    _indexModel.Language = LanguageCodes.English;
                    _indexModel.OnPost();
                    _cache.TryGetValue(_cacheKey, out string languageCode);
                    languageCode.ShouldBeEqualTo("en");
                }
            }
        }
    }
}