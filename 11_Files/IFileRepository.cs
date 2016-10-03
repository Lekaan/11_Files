namespace _11_Files
{
    internal interface IFileRepository : IStockRepository
    {
        string StockFileName(int fileId);
        string StockFileName(Stock hp);
        void SaveStock(Stock yhoo);
    }
}