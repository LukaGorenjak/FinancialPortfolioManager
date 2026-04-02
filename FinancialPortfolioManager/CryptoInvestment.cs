using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Predstavlja kriptovalutno naložbo. Implementira <see cref="IStakeable"/>.
    /// </summary>
    internal class CryptoInvestment : Investment, IStakeable
    {
        /// <summary>Vrsta naložbe — vedno <see cref="InvestmentType.Crypto"/>.</summary>
        public override InvestmentType Type => InvestmentType.Crypto;

        /// <summary>Ime verige blokov, na kateri temelji kriptovaluta (npr. "Ethereum", "Bitcoin").</summary>
        public string Blockchain { get; set; }

        /// <summary>Označuje, ali je kriptovaluta stabilna (stablecoin).</summary>
        public bool IsStablecoin { get; set; }

        /// <summary>Letni donos stakanja kot decimalni delež (npr. 0,06 za 6 %).</summary>
        public decimal StakingYield { get; set; }

        /// <summary>
        /// Ustvari novo kriptovalutno naložbo.
        /// </summary>
        /// <param name="ticker">Simbol kriptovalute (npr. "BTC", "ETH").</param>
        /// <param name="name">Polno ime kriptovalute.</param>
        /// <param name="amount">Količina enot v lasti.</param>
        /// <param name="buyPrice">Nakupna cena na enoto.</param>
        public CryptoInvestment(string ticker, string name, decimal amount, decimal buyPrice)
            : base(name, amount, buyPrice)
        {
            Ticker = ticker;
        }

        /// <summary>
        /// Vrne trenutno tržno vrednost kriptovalutne naložbe (trenutna cena × količina).
        /// </summary>
        /// <returns>Tržna vrednost kot <see cref="decimal"/>.</returns>
        public override decimal GetValue()
        {
            return CurrentPrice * Amount;
        }

        /// <summary>
        /// Izračuna letne nagrade za stakanje na podlagi trenutne vrednosti naložbe.
        /// </summary>
        /// <returns>Letne nagrade za stakanje kot <see cref="decimal"/>.</returns>
        public decimal GetAnnualStakingRewards()
        {
            return CurrentPrice * Amount * StakingYield;
        }

        /// <summary>
        /// Vrne oceno tveganja: 0,2 za stablecoins, 0,8 za ostale kriptovalute.
        /// </summary>
        /// <returns>Ocena tveganja kot <see cref="decimal"/> med 0 in 1.</returns>
        public override decimal GetRiskScore()
        {
            if (IsStablecoin)
                return 0.2m;

            return 0.8m;
        }

        /// <summary>
        /// Vrne podrobnosti kriptovalutne naložbe: simbol, ime, veriga blokov, donos stakanja in ali je stablecoin.
        /// </summary>
        /// <returns>Niz s podrobnostmi naložbe.</returns>
        public override string GetDetails()
        {
            return $"{Summary} | Chain: {Blockchain}, Staking Yield: {StakingYield:P2}, Stablecoin: {IsStablecoin}";
        }
    }
}
