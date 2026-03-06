using System;

namespace FinancialPortfolioManager
{
    public interface IStakeable
    {
        decimal StakingYield { get; }

        decimal GetAnnualStakingRewards();
    }
}

