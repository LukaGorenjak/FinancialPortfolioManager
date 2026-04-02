using System;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Vmesnik za naložbe, ki ponujajo nagrade za stakanje.
    /// </summary>
    public interface IStakeable
    {
        /// <summary>
        /// Letni donos stakanja, izražen kot decimalni delež (npr. 0,06 za 6 %).
        /// </summary>
        decimal StakingYield { get; }

        /// <summary>
        /// Izračuna letne nagrade za stakanje za to naložbo.
        /// </summary>
        /// <returns>Letne nagrade za stakanje kot <see cref="decimal"/>.</returns>
        decimal GetAnnualStakingRewards();
    }
}
