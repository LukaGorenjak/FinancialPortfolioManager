using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Upravljalec finančnega portfelja. Hrani naložbe, transakcije in stanje gotovine.
    /// Ob vsaki spremembi sproži dogodek <see cref="PortfolioChanged"/>.
    /// </summary>
    public class Portfolio
    {
        private readonly List<Investment> investments = new List<Investment>();
        private readonly List<Transaction> transactions = new();

        /// <summary>
        /// Delegat za obravnavo dogodka <see cref="PortfolioChanged"/>.
        /// </summary>
        /// <param name="sender">Vir dogodka (portfelj).</param>
        /// <param name="e">Podatki o spremembi portfelja.</param>
        public delegate void PortfolioChangedHandler(object sender, PortfolioChangedEventArgs e);

        /// <summary>
        /// Dogodek, ki se sproži ob vsaki spremembi portfelja (nakup, prodaja, polog, dvig, dodajanje ali odstranjevanje naložbe).
        /// </summary>
        public event PortfolioChangedHandler PortfolioChanged;

        /// <summary>
        /// Sproži dogodek <see cref="PortfolioChanged"/> z navedenim dejanjem in prizadetim objektom.
        /// </summary>
        /// <param name="action">Opis dejanja (npr. "AddInvestment", "Deposit").</param>
        /// <param name="affectedObject">Objekt, ki ga je sprememba prizadela.</param>
        protected virtual void OnPortfolioChanged(string action, object affectedObject)
        {
            PortfolioChanged?.Invoke(this, new PortfolioChangedEventArgs(action, affectedObject));
        }

        /// <summary>Trenutna valuta portfelja ("EUR" ali "USD").</summary>
        public static string currency = "EUR";

        /// <summary>Stanje gotovine v portfelju. Privzeto je 1000 EUR ob ustvaritvi.</summary>
        public decimal CashBalance { get; private set; } = 1000m;

        /// <summary>
        /// Vrne seznam vseh transakcij kot samo za branje.
        /// </summary>
        /// <returns>Samo za branje seznam <see cref="Transaction"/>.</returns>
        public IReadOnlyList<Transaction> GetTransactions()
        {
            return transactions.AsReadOnly();
        }

        /// <summary>
        /// Doda znesek gotovine v portfelj in sproži <see cref="PortfolioChanged"/>.
        /// </summary>
        /// <param name="amount">Znesek pologa. Vrednosti ≤ 0 so prezrte.</param>
        public void Deposit(decimal amount)
        {
            if (amount <= 0) return;
            CashBalance += amount;
            OnPortfolioChanged("Deposit", amount);
        }

        /// <summary>
        /// Dvigne znesek gotovine iz portfelja, če je stanje zadostno. Sproži <see cref="PortfolioChanged"/>.
        /// </summary>
        /// <param name="amount">Znesek dviga.</param>
        /// <returns><c>true</c> če je dvig uspel; <c>false</c> če sredstev ni dovolj ali je znesek neveljaven.</returns>
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > CashBalance)
                return false;

            CashBalance -= amount;
            OnPortfolioChanged("Withdraw", amount);
            return true;
        }

        /// <summary>
        /// Doda naložbo v portfelj. Če naložba z istim simbolom in tipom že obstaja, se količini združita
        /// z izračunom tehtane povprečne nakupne cene. V tem primeru <see cref="PortfolioChanged"/> ni sprožen.
        /// </summary>
        /// <param name="investment">Naložba za dodajanje.</param>
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

        /// <summary>
        /// Vrne seznam vseh naložb kot samo za branje.
        /// </summary>
        /// <returns>Samo za branje seznam <see cref="Investment"/>.</returns>
        public IReadOnlyList<Investment> GetInvestments()
        {
            return investments.AsReadOnly();
        }

        /// <summary>
        /// Izračuna skupno vrednost portfelja (gotovina + vse naložbe).
        /// </summary>
        /// <returns>Skupna vrednost portfelja kot <see cref="decimal"/>.</returns>
        public decimal GetTotalValue()
        {
            return CashBalance + FinancialPortfolioManager.Library.PortfolioLibrary.CalculateTotalValue(investments);
        }

        /// <summary>
        /// Izračuna skupen dobiček ali izgubo za vse naložbe v portfelju.
        /// </summary>
        /// <returns>Skupni dobiček/izguba kot <see cref="decimal"/>.</returns>
        public decimal GetTotalProfitLoss()
        {
            return investments.Sum(i => i.GetProfitLoss());
        }

        /// <summary>
        /// Preklopi valuto portfelja med EUR in USD.
        /// </summary>
        public static void ChangeCurrency()
        {
            currency = currency == "EUR" ? "USD" : "EUR";
        }

        /// <summary>
        /// Vrne skupno vrednost naložb določenega tipa (za gotovino vrne <see cref="CashBalance"/>).
        /// </summary>
        /// <param name="type">Vrsta naložbe za izračun vrednosti.</param>
        /// <returns>Vrednost naložb danega tipa kot <see cref="decimal"/>.</returns>
        public decimal GetValueByType(InvestmentType type)
        {
            if (type == InvestmentType.Cash)
                return CashBalance;

            return investments
                .Where(i => i.Type == type)
                .Sum(i => i.GetValue());
        }

        /// <summary>
        /// Vrne odstotek skupne vrednosti portfelja za naložbe določenega tipa.
        /// </summary>
        /// <param name="type">Vrsta naložbe.</param>
        /// <returns>Odstotek kot <see cref="decimal"/> (0–100). Vrne 0, če je skupna vrednost 0.</returns>
        public decimal GetPercentageByType(InvestmentType type)
        {
            decimal total = GetTotalValue();
            if (total == 0) return 0;

            return (GetValueByType(type) / total) * 100;
        }

        /// <summary>
        /// Odstrani naložbo iz portfelja in sproži <see cref="PortfolioChanged"/>.
        /// </summary>
        /// <param name="investment">Naložba za odstranitev.</param>
        public void RemoveInvestment(Investment investment)
        {
            investments.Remove(investment);
            OnPortfolioChanged("RemoveInvestment", investment);
        }

        /// <summary>
        /// Dostop do naložbe po indeksu.
        /// </summary>
        /// <param name="index">Indeks naložbe v notranjem seznamu.</param>
        /// <returns>Naložba na danem indeksu.</returns>
        public Investment this[int index]
        {
            get { return investments[index]; }
        }

        /// <summary>
        /// Dostop do naložbe po simbolu (primerjava ni občutljiva na velikost črk).
        /// </summary>
        /// <param name="ticker">Simbol naložbe za iskanje.</param>
        /// <returns>Naložba s tem simbolom ali <c>null</c>, če ni najdena.</returns>
        public Investment this[string ticker]
        {
            get
            {
                return investments.FirstOrDefault(
                    i => i.Ticker.Equals(ticker, StringComparison.OrdinalIgnoreCase)
                );
            }
        }

        /// <summary>
        /// Doda transakcijo v zgodovino in nastavi njeno zastavico nakupa/prodaje. Sproži <see cref="PortfolioChanged"/>.
        /// </summary>
        /// <param name="transaction">Transakcija za dodajanje.</param>
        /// <param name="isBuy"><c>true</c> za nakup, <c>false</c> za prodajo.</param>
        public void AddTransaction(Transaction transaction, bool isBuy)
        {
            transaction.IsBuy = isBuy;
            transactions.Add(transaction);
            OnPortfolioChanged("AddTransaction", transaction);
        }

        /// <summary>
        /// Združi dva portfelja v novega. Gotovina in naložbe obeh se seštejejo.
        /// </summary>
        /// <param name="a">Prvi portfelj.</param>
        /// <param name="b">Drugi portfelj.</param>
        /// <returns>Nov <see cref="Portfolio"/> z združeno gotovino in naložbami obeh portfeljev.</returns>
        public static Portfolio operator +(Portfolio a, Portfolio b)
        {
            Portfolio result = new Portfolio();
            result.CashBalance = a.CashBalance + b.CashBalance;
            foreach (var i in a.investments) result.AddInvestment(i);
            foreach (var i in b.investments) result.AddInvestment(i);
            return result;
        }
    }
}
