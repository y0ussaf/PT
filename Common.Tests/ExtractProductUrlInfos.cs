using Common.Helpers.ProductUrlInfosExtractors;
using Common.Helpers.ProductUrlInfosExtractors.Amazon;
using NUnit.Framework;

namespace Common.Tests
{
    [TestFixture]
    public class ExtractProductUrlInfos
    {
         
        [Test]
        [TestCase("https://www.amazon.co.uk/PALICOMP-NVIDIA-Gaming-3-7Ghz-Turbo/dp/B01DWE1T4Q/",true, "uk","B01DWE1T4Q")]
        [TestCase("https://www.amazon.fr/Pro-SQL-Server-2019-Administration/dp/1484250885",true,"fr","1484250885")]
        [TestCase("https://www.amazon.fr/Pro-SQL-Server-2019-Administration/1484250885",false,null,null)]
        public void ValidAmazonProductUrl(string productUrl,bool success,string location,string productId)
        {
            var urlInfosExtractor = new AmazonProductUrlInfosExtractor();
            ProductUrlInfos productUrlInfos = urlInfosExtractor.Extract(productUrl);
            Assert.That(productUrlInfos.Success,Is.EqualTo(success));
            Assert.That(productUrlInfos.Location,Is.EqualTo(location));
            Assert.That(productUrlInfos.ProductId,Is.EqualTo(productId));
        }
         
    }
}
