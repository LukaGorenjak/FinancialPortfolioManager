using System;

namespace FinancialPortfolioManager
{
    public interface IDividendPaying
    {
        decimal DividendYield { get; }

        decimal GetAnnualDividendIncome();
    }
}

