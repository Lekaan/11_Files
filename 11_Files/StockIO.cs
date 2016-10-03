using System;
using System.IO;

namespace _11_Files
{
    internal class StockIO
    {
        internal void WriteStock(StringWriter sw, Stock hp)
        {
            sw.WriteLine(hp.GetName().ToUpper());
            sw.WriteLine(hp.PricePerShare.ToString("F1"));
            sw.WriteLine(hp.NumShares);
        }

        internal Stock ReadStock(StringReader data)
        {
            string name = data.ReadLine();
            double pricePerShare = Double.Parse(data.ReadLine());
            int numOfShares = Int32.Parse(data.ReadLine());

            return new Stock(name, pricePerShare, numOfShares);
        }

        internal void WriteStock(FileInfo output, Stock hp)
        {
            using (StreamWriter writer = output.AppendText())
            {
                writer.WriteLine(hp.Symbol);
                writer.WriteLine(hp.PricePerShare);
                writer.WriteLine(hp.NumShares);
            }
        }

        internal Stock ReadStock(FileInfo output)
        {
            using(StreamReader reader = output.OpenText())
            {
                string name = reader.ReadLine();
                double pricePerShare = Double.Parse(reader.ReadLine());
                int numOfShares = Int32.Parse(reader.ReadLine());

                return new Stock(name, pricePerShare, numOfShares);
            }
            
        }
    }
}