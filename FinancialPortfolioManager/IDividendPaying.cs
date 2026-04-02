using System;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Vmesnik za naložbe, ki izplačujejo dividende.
    /// </summary>
    public interface IDividendPaying
    {
        /// <summary>
        /// Letni dividendni donos, izražen kot decimalni delež (npr. 0,03 za 3 %).
        /// </summary>
        decimal DividendYield { get; }

        /// <summary>
        /// Izračuna letni prihodek od dividend za to naložbo.
        /// </summary>
        /// <returns>Letni prihodek od dividend kot <see cref="decimal"/>.</returns>
        decimal GetAnnualDividendIncome();
    }
}
