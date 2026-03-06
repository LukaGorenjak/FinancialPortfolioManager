using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    internal class StockInvestment : Investment, IDividendPaying
    {
        public override InvestmentType Type => InvestmentType.Stock;

        public decimal DividendYield { get; set; }

        public string Exchange { get; set; }

        public string Sector { get; set; }

        public bool IsEtf { get; set; }

        public StockInvestment(string ticker, string name, decimal amount, decimal buyPrice)
            : base(name, amount, buyPrice)
        {
            Ticker = ticker;
        }

        public override decimal GetValue()
        {
            return CurrentPrice * Amount;
        }

        public decimal GetAnnualDividendIncome()
        {
            return CurrentPrice * Amount * DividendYield;
        }

        public decimal GetTotalReturn()
        {
            return GetProfitLoss() + GetAnnualDividendIncome();
        }

        public override decimal GetRiskScore()
        {
            decimal baseRisk = 0.5m;

            if (IsEtf)
                baseRisk -= 0.1m;

            return Math.Clamp(baseRisk, 0m, 1m);
        }

        public override string GetDetails()
        {
            return $"{Summary} | Exchange: {Exchange}, Sector: {Sector}, Dividend Yield: {DividendYield:P2}";
        }
    }
}
