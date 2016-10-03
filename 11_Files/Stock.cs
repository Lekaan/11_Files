using System;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace _11_Files
{
    internal class Stock : IAsset
    {
        public string Symbol { get; set; }
        
        public double PricePerShare { get; set; }
        public int NumShares { get; set; }
        public long Id { get; internal set; }

        public Stock()
        {
            
        }

        public Stock(string stockName, double PricePerShare, int NumShares)
        {
            Symbol = stockName;
            this.PricePerShare = PricePerShare;
            this.NumShares = NumShares;
        }

        public override string ToString()
        {
            return "Stock[symbol=" + Symbol + ",pricePerShare=" + PricePerShare.ToString().Replace(",", ".") + ",numShares=" + NumShares + "]";
        }

        public override bool Equals(object obj)
        {
            Stock stock = (Stock) obj;

            if (Symbol != stock.Symbol)
                return false;
            if (PricePerShare != stock.PricePerShare)
                return false;
            if(NumShares != stock.NumShares)
                return false;
            
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public double GetValue()
        {
            return PricePerShare * NumShares;
        }

        internal static double TotalValue(Stock[] stocks)
        {
            double result= 0;

            foreach (Stock stock in stocks)
                result += stock.GetValue();
            
            return result;
        }

        internal static object TotalValue(IAsset[] portfolio)
        {
            double result = 0;

            foreach (IAsset asset in portfolio)
                result += asset.GetValue();

            return result;
        }

        public string GetName()
        {
            return Symbol;
        }
    }
}