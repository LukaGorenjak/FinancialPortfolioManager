using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Abstraktni osnovni razred za vse vrste naložb v portfelju.
    /// Implementira vmesnik <see cref="IValuable"/>.
    /// </summary>
    public abstract class Investment : IValuable
    {
        /// <summary>Najmanjša dovoljena količina naložbe.</summary>
        public const decimal MIN_INVESTMENT_AMOUNT = 0.01m;

        private string name;
        private decimal amount;
        private decimal buyPrice;
        private string ticker;

        /// <summary>Polno ime naložbe.</summary>
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        /// <summary>
        /// Količina enot naložbe v lasti. Mora biti vsaj <see cref="MIN_INVESTMENT_AMOUNT"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Če je vrednost manjša od <see cref="MIN_INVESTMENT_AMOUNT"/>.</exception>
        public decimal Amount
        {
            get { return amount; }
            set {
                if (value < MIN_INVESTMENT_AMOUNT)
                    throw new ArgumentException($"Amount must be at least {MIN_INVESTMENT_AMOUNT}.");
                amount = value;
            }
        }

        /// <summary>Povprečna nakupna cena na enoto.</summary>
        public decimal BuyPrice
        {
            get { return buyPrice; }
            set { buyPrice = value; }
        }

        /// <summary>Borznointervalni simbol naložbe (npr. "AAPL", "BTC").</summary>
        public string Ticker
        {
            get { return ticker; }
            protected set { ticker = value; }
        }

        /// <summary>Trenutna tržna cena naložbe na enoto.</summary>
        public decimal CurrentPrice { get; protected set; }

        /// <summary>Vrsta naložbe (Stock, Crypto). Implementirajo izvedeni razredi.</summary>
        public abstract InvestmentType Type { get; }

        /// <summary>
        /// Ustvari osnovno naložbo.
        /// </summary>
        /// <param name="name">Polno ime naložbe.</param>
        /// <param name="amount">Začetna količina enot.</param>
        /// <param name="buyPrice">Nakupna cena na enoto; nastavi se tudi kot začetna trenutna cena.</param>
        protected Investment(string name, decimal amount, decimal buyPrice)
        {
            Name = name;
            Amount = amount;
            BuyPrice = buyPrice;
            CurrentPrice = buyPrice;
        }

        /// <summary>
        /// Vrne trenutno tržno vrednost naložbe.
        /// </summary>
        /// <returns>Vrednost naložbe kot <see cref="decimal"/>.</returns>
        public abstract decimal GetValue();

        /// <summary>
        /// Vrne oceno tveganja naložbe na lestvici od 0 (nizko) do 1 (visoko).
        /// </summary>
        /// <returns>Ocena tveganja kot <see cref="decimal"/> med 0 in 1.</returns>
        public abstract decimal GetRiskScore();

        /// <summary>
        /// Kratki povzetek naložbe v obliki "{Ticker} - {Name}: {Amount} @ {BuyPrice:N2} ({Type})".
        /// </summary>
        public string Summary
        {
            get
            {
                return $"{Ticker} - {Name}: {Amount} @ {BuyPrice:N2} ({Type})";
            }
        }

        /// <summary>
        /// Izračuna realiziran dobiček ali izgubo glede na nakupno ceno.
        /// </summary>
        /// <returns>Dobiček ali izguba kot <see cref="decimal"/> (pozitivna = dobiček, negativna = izguba).</returns>
        public virtual decimal GetProfitLoss()
        {
            return (CurrentPrice - BuyPrice) * Amount;
        }

        /// <summary>
        /// Vrne podrobnosti naložbe. Privzeto vrne <see cref="Summary"/>.
        /// </summary>
        /// <returns>Niz z opisi naložbe.</returns>
        public virtual string GetDetails()
        {
            return Summary;
        }

        /// <summary>
        /// Združi dve naložbi istega tipa in simbola v eno. Izračuna tehtano povprečno nakupno ceno.
        /// </summary>
        /// <param name="a">Prva naložba.</param>
        /// <param name="b">Druga naložba.</param>
        /// <returns>Nova naložba z združeno količino in tehtano povprečno nakupno ceno.</returns>
        /// <exception cref="ArgumentNullException">Če je ena od naložb <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Če naložbi nista istega tipa ali simbola.</exception>
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

        /// <summary>
        /// Destruktor — ob uničenju izpiše diagnostično sporočilo za razhroščevanje.
        /// </summary>
        ~Investment()
        {
            System.Diagnostics.Debug.WriteLine($"Investment {ticker} has been finalized.");
        }
    }
}
