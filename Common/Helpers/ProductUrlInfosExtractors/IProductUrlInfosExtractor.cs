namespace Common.Helpers.ProductUrlInfosExtractors
{
    public  interface IProductUrlInfosExtractor
    {
        public ProductUrlInfos Extract(string productUrl);
    }
}