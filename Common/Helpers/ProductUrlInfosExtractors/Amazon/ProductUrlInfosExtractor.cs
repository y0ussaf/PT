using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Common.Helpers.ProductUrlInfosExtractors.Amazon
{
    public class AmazonProductUrlInfosExtractor : IProductUrlInfosExtractor
    {
        private static Regex _regex =
            new Regex(@"amazon\.(?:(?:co\.)?(?'location'\w{2}))/.*/dp/(?'product_id'[^/.]+)/?");
         public ProductUrlInfos Extract(string productUrl)
        {
            ProductUrlInfos productUrlInfos = new ProductUrlInfos {Success = false};
            Match match = _regex.Match(productUrl); 
            if (match.Success)
            {
                productUrlInfos.ProductId = match.Groups["product_id"].Value;
                productUrlInfos.Location = match.Groups["location"].Value;
                productUrlInfos.Success = true;
            }
            return productUrlInfos;
        }
    }
}