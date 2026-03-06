using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    public class Portfolio
    {
        private readonly List<Investment> investments = new List<Investment>();
        private readonly List<Transaction> transactions = new();

        public delegate void PortfolioChangedHandler(object sender, PortfolioChangedEventArgs e);
        public event PortfolioChangedHandler PortfolioChanged;

        protected virtual void OnPortfolioChanged(string action, object affectedObject)
        {
            PortfolioChanged?.Invoke(this, new PortfolioChangedEventArgs(action, affectedObject));
        }

        public static string currency = "EUR";

        public decimal CashBalance { get; private set; } = 1000m;

        public IReadOnlyList<Transaction> GetTransactions()
        {
            return transactions.AsReadOnly();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) return;
            CashBalance += amount;
            OnPortfolioChanged("Deposit", amount);
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > CashBalance)
                return false;

            CashBalance -= amount;
            OnPortfolioChanged("Withdraw", amount);
            return true;
        }

        public void AddInvestment(Investment investment)
        {
            Investment existing = null;

            foreach (var inv in investments)
            {
                if (inv.Ticker == investment.Ticker &&
                    inv.Type == investment.Type)
                {
                    existing = inv;
                    break;
                }
            }

            if (existing != null)
            {
                Investment combined = existing + investment;
                existing.Amount = combined.Amount;
                existing.BuyPrice = combined.BuyPrice;
            }
            else
            {
                investments.Add(investment);
                OnPortfolioChanged("AddInvestment", investment);
            }

        }


        public IReadOnlyList<Investment> GetInvestments()
        {
            return investments.AsReadOnly();
        }

        public decimal GetTotalValue()
        {
            //decimal totalSum = 0;

            //for (int i = 0; i < investments.Count; i++)
            //{
            //    totalSum += investments[i].GetValue();
            //}

            //return totalSum;

            return CashBalance + FinancialPortfolioManager.Library.PortfolioLibrary.CalculateTotalValue(investments);
        }

        public decimal GetTotalProfitLoss()
        {
            return investments.Sum(i => i.GetProfitLoss());
        }

        public static void ChangeCurrency()
        {
            currency = currency == "EUR" ? "USD" : "EUR";
        }

        public decimal GetValueByType(InvestmentType type)
        {
            if (type == InvestmentType.Cash)
                return CashBalance;

            return investments
                .Where(i => i.Type == type)
                .Sum(i => i.GetValue());
        }

        public decimal GetPercentageByType(InvestmentType type)
        {
            decimal total = GetTotalValue();
            if (total == 0) return 0;

            return (GetValueByType(type) / total) * 100;
        }

        public void RemoveInvestment(Investment investment)
        {
            investments.Remove(investment);
            OnPortfolioChanged("RemoveInvestment", investment);
        }

        public Investment this[int index]
        {
            get { return investments[index]; }
        }

        public Investment this[string ticker]
        {
            get
            {
                return investments.FirstOrDefault(
                    i => i.Ticker.Equals(ticker, StringComparison.OrdinalIgnoreCase)
                );
            }
        }

        public void AddTransaction(Transaction transaction, bool isBuy)
        {
            transaction.IsBuy = isBuy;
            transactions.Add(transaction);
            OnPortfolioChanged("AddTransaction", transaction);
        }

        public static Portfolio operator +(Portfolio a, Portfolio b)
        {
            Portfolio result = new Portfolio();
            foreach (var i in a.investments) result.AddInvestment(i);
            foreach (var i in b.investments) result.AddInvestment(i);
            return result;
        }
    }
}
