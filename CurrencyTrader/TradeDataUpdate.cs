using CurrencyTrader.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyTrader
{
    public class TradeDataUpdate : ITradeDataUpdate
    {
        ListBox.ObjectCollection tradeItems;
        public TradeDataUpdate(ListBox.ObjectCollection items)
        {
            this.tradeItems = items;
        }
        
        public void UpdateTradeData(IEnumerable<string> lines)
        {
            foreach(string line in lines)
            {
                // Parse the lines to the tradeItems collection
                tradeItems.Add(line);
            }

            // Update the trade data
        }
    }
}
