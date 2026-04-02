using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Predstavlja posamezno nakupno ali prodajno transakcijo naložbe.
    /// </summary>
    public class Transaction
    {
        /// <summary>Datum in čas izvedbe transakcije.</summary>
        public DateTime Date { get; }

        /// <summary>Borznointervalni simbol naložbe (npr. "AAPL", "BTC").</summary>
        public string Ticker { get; }

        /// <summary>Polno ime naložbe.</summary>
        public string Name { get; }

        /// <summary>Količina enot v transakciji.</summary>
        public decimal Amount { get; }

        /// <summary>Cena na enoto ob izvedbi transakcije.</summary>
        public decimal Price { get; }

        /// <summary>Vrsta naložbe (Stock, Crypto).</summary>
        public InvestmentType Type { get; }

        /// <summary>
        /// Označuje, ali gre za nakup (<c>true</c>) ali prodajo (<c>false</c>).
        /// </summary>
        public bool IsBuy { get; set; }

        /// <summary>
        /// Ustvari novo transakcijo. Datum se samodejno nastavi na trenutni čas.
        /// </summary>
        /// <param name="ticker">Borznointervalni simbol naložbe.</param>
        /// <param name="name">Polno ime naložbe.</param>
        /// <param name="amount">Količina enot.</param>
        /// <param name="price">Cena na enoto.</param>
        /// <param name="type">Vrsta naložbe.</param>
        public Transaction(string ticker, string name, decimal amount, decimal price, InvestmentType type)
        {
            Date = DateTime.Now;
            Ticker = ticker;
            Name = name;
            Amount = amount;
            Price = price;
            Type = type;
        }

        /// <summary>
        /// Skupna vrednost transakcije (količina × cena).
        /// </summary>
        /// <returns>Skupna vrednost kot <see cref="decimal"/>.</returns>
        public decimal TotalValue => Amount * Price;
    }
}
