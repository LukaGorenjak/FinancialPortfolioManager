using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    internal class CryptoInvestment : Investment, IStakeable
    {
        public override InvestmentType Type => InvestmentType.Crypto;

        public string Blockchain { get; set; }

        public bool IsStablecoin { get; set; }

        public decimal StakingYield { get; set; }

        public CryptoInvestment(string ticker, string name, decimal amount, decimal buyPrice)
            : base(name, amount, buyPrice)
        {
            Ticker = ticker;
        }

        public override decimal GetValue()
        {
            return CurrentPrice * Amount;
        }

        public decimal GetAnnualStakingRewards()
        {
            return CurrentPrice * Amount * StakingYield;
        }

        public override decimal GetRiskScore()
        {
            if (IsStablecoin)
                return 0.2m;

            return 0.8m;
        }

        public override string GetDetails()
        {
            return $"{Summary} | Chain: {Blockchain}, Staking Yield: {StakingYield:P2}, Stablecoin: {IsStablecoin}";
        }
    }
}
