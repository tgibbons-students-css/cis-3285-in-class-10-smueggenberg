using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;

namespace CurrencyTrader
{
    public class AsynchUrlTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        private readonly UrlTradeDataProvider SynchTradeProvider;

        public AsynchUrlTradeDataProvider(String url)
        {
            this.url = url;
            this.SynchTradeProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            //var tradeData = SynchTradeProvider.GetTradeData();

            Task.Run(() => SynchTradeProvider.GetTradeData());

            //return tradeData;
        }
    }
}
