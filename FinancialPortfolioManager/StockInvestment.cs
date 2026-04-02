using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Predstavlja delniško naložbo ali ETF. Implementira <see cref="IDividendPaying"/>.
    /// </summary>
    internal class StockInvestment : Investment, IDividendPaying
    {
        /// <summary>Vrsta naložbe — vedno <see cref="InvestmentType.Stock"/>.</summary>
        public override InvestmentType Type => InvestmentType.Stock;

        /// <summary>Letni dividendni donos kot decimalni delež (npr. 0,03 za 3 %).</summary>
        public decimal DividendYield { get; set; }

        /// <summary>Borza, na kateri je delnica kotirana (npr. "NYSE", "NASDAQ").</summary>
        public string Exchange { get; set; }

        /// <summary>Gospodarski sektor naložbe (npr. "Technology", "Healthcare").</summary>
        public string Sector { get; set; }

        /// <summary>Označuje, ali gre za ETF (<c>true</c>) ali navadno delnico (<c>false</c>).</summary>
        public bool IsEtf { get; set; }

        /// <summary>
        /// Ustvari novo delniško naložbo.
        /// </summary>
        /// <param name="ticker">Borznointervalni simbol (npr. "AAPL").</param>
        /// <param name="name">Polno ime podjetja ali ETF.</param>
        /// <param name="amount">Število delnic v lasti.</param>
        /// <param name="buyPrice">Nakupna cena na delnico.</param>
        public StockInvestment(string ticker, string name, decimal amount, decimal buyPrice)
            : base(name, amount, buyPrice)
        {
            Ticker = ticker;
        }

        /// <summary>
        /// Vrne trenutno tržno vrednost delniške naložbe (trenutna cena × količina).
        /// </summary>
        /// <returns>Tržna vrednost kot <see cref="decimal"/>.</returns>
        public override decimal GetValue()
        {
            return CurrentPrice * Amount;
        }

        /// <summary>
        /// Izračuna letni prihodek od dividend na podlagi trenutne vrednosti naložbe.
        /// </summary>
        /// <returns>Letni dividendni prihodek kot <see cref="decimal"/>.</returns>
        public decimal GetAnnualDividendIncome()
        {
            return CurrentPrice * Amount * DividendYield;
        }

        /// <summary>
        /// Izračuna skupni donos naložbe (kapitalski dobiček + letne dividende).
        /// </summary>
        /// <returns>Skupni donos kot <see cref="decimal"/>.</returns>
        public decimal GetTotalReturn()
        {
            return GetProfitLoss() + GetAnnualDividendIncome();
        }

        /// <summary>
        /// Vrne oceno tveganja: 0,4 za ETF, 0,5 za navadne delnice (razpon 0–1).
        /// </summary>
        /// <returns>Ocena tveganja kot <see cref="decimal"/> med 0 in 1.</returns>
        public override decimal GetRiskScore()
        {
            decimal baseRisk = 0.5m;

            if (IsEtf)
                baseRisk -= 0.1m;

            return Math.Clamp(baseRisk, 0m, 1m);
        }

        /// <summary>
        /// Vrne podrobnosti delniške naložbe: simbol, ime, borza, sektor in dividendni donos.
        /// </summary>
        /// <returns>Niz s podrobnostmi naložbe.</returns>
        public override string GetDetails()
        {
            return $"{Summary} | Exchange: {Exchange}, Sector: {Sector}, Dividend Yield: {DividendYield:P2}";
        }
    }
}
