using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;
using System.Net;

namespace CurrencyTrader
{
    public class AsynchUrlTradeDataProvider : IAsynchUrlTradeDataProvider
    {
        private readonly String url;
        private readonly UrlTradeDataProvider SynchTradeProvider;
        static TradeDataUpdate tradeUpdater;

        public AsynchUrlTradeDataProvider(String url, TradeDataUpdate newTradeUpdater)
        {
            this.url = url;
            this.SynchTradeProvider = new UrlTradeDataProvider(url);
            tradeUpdater = newTradeUpdater;
        }

        public void GetTradeData()
        {
            //var tradeData = SynchTradeProvider.GetTradeData();
            //Task.Run(() => SynchTradeProvider.GetTradeData());
            //return tradeData;

            WebClient wclient = new WebClient();
            wclient.DownloadStringCompleted += DownloadStringCompleted;
            wclient.DownloadStringAsync(new Uri(url));
        }

        static void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string[] lines = e.Result.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            tradeUpdater.UpdateTradeData(lines);
        }
    }
}
