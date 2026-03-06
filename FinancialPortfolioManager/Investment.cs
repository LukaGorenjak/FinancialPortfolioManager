using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    public abstract class Investment : IValuable
    {
        public const decimal MIN_INVESTMENT_AMOUNT = 0.01m;

        private string name;
        private decimal amount;
        private decimal buyPrice;
        private string ticker;

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set {
                if (value < MIN_INVESTMENT_AMOUNT)
                    throw new ArgumentException($"Amount must be at least {MIN_INVESTMENT_AMOUNT}.");
                amount = value;
            }
        }

        public decimal BuyPrice
        {
            get { return buyPrice; }
            set { buyPrice = value; }
        }

        public string Ticker
        {
            get { return ticker; }
            protected set { ticker = value; }
        }

        public decimal CurrentPrice { get; protected set; }

        public abstract InvestmentType Type { get; }

        protected Investment(string name, decimal amount, decimal buyPrice)
        {
            Name = name;
            Amount = amount;
            BuyPrice = buyPrice;
            CurrentPrice = buyPrice; 
        }

        public abstract decimal GetValue();

        public abstract decimal GetRiskScore();

        public string Summary
        {
            get
            {
                return $"{Ticker} - {Name}: {Amount} @ {BuyPrice:N2} ({Type})";
            }
        }

        public virtual decimal GetProfitLoss()
        {
            return (CurrentPrice - BuyPrice) * Amount;
        }

        public virtual string GetDetails()
        {
            return Summary;
        }

        public static Investment operator +(Investment a, Investment b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Investments cannot be null.");

            if (a.Type != b.Type || a.Ticker != b.Ticker)
                throw new InvalidOperationException("Can only add investments of the same type and ticker.");

            decimal totalAmount = a.Amount + b.Amount;
            decimal totalCost = (a.Amount * a.BuyPrice) + (b.Amount * b.BuyPrice);
            decimal avgBuyPrice = totalCost / totalAmount;

            if (a.Type == InvestmentType.Stock)
            {
                return new StockInvestment(a.Ticker, a.Name, totalAmount, avgBuyPrice)
                {
                    CurrentPrice = a.CurrentPrice 
                };
            }
            else if (a.Type == InvestmentType.Crypto)
            {
                return new CryptoInvestment(a.Ticker, a.Name, totalAmount, avgBuyPrice)
                {
                    CurrentPrice = a.CurrentPrice
                };
            }
            else
            {
                throw new InvalidOperationException("Addition not supported for this investment type.");
            }
        }


        ~Investment()
        {
            System.Diagnostics.Debug.WriteLine($"Investment {ticker} has been finalized.");
        }
    }
}
