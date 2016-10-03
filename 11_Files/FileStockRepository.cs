using System;
using System.Collections;
using System.IO;

namespace _11_Files
{
    internal class FileStockRepository : IStockRepository, IFileRepository
    {
        private DirectoryInfo repositoryDir;
        private long id = 1;

        public FileStockRepository(DirectoryInfo repositoryDir)
        {
            this.repositoryDir = repositoryDir;
        }

        public long NextId()
        {
            return ++id;
        }

        public string StockFileName(int fileId)
        {
            return "stock" + fileId + ".txt";
        }
        

        public void SaveStock(Stock yhoo)
        {
            yhoo.Id = id;
            FileInfo output = new FileInfo(repositoryDir + "stock" + yhoo.Id + ".txt");
            using (StreamWriter writer = output.AppendText())
            {
                writer.WriteLine(yhoo.Symbol);
                writer.WriteLine(yhoo.PricePerShare);
                writer.WriteLine(yhoo.NumShares);
            }
            ++id;
        }

        string IFileRepository.StockFileName(Stock hp)
        {
            return "stock" + hp.Id + ".txt";
        }

        public Stock LoadStock(long id)
        {
            FileInfo output = new FileInfo(repositoryDir + "stock" + id + ".txt");
            using (StreamReader reader = output.OpenText())
            {
                string name = reader.ReadLine();
                double pricePerShare = Double.Parse(reader.ReadLine());
                int numOfShares = Int32.Parse(reader.ReadLine());

                return new Stock(name, pricePerShare, numOfShares);
            }
        }

        public void Clear()
        {
            foreach (FileInfo output in repositoryDir.GetFiles())
            {
                output.Delete();
            }
        }

        public ICollection FindAllStocks()
        {
            ICollection allFiles = repositoryDir.GetFiles();
            return allFiles;
        }
    }
}