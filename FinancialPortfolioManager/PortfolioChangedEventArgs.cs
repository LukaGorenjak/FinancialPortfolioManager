using System;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Vsebuje podatke o spremembi portfelja, ki jih prenaša dogodek <see cref="Portfolio.PortfolioChanged"/>.
    /// </summary>
    public class PortfolioChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Vrsta dejanja, ki je sprožilo spremembo (npr. "AddInvestment", "Deposit", "Withdraw").
        /// </summary>
        public string Action { get; }

        /// <summary>
        /// Objekt, na katerega se nanaša sprememba (naložba, transakcija ali znesek).
        /// </summary>
        public object AffectedObject { get; }

        /// <summary>
        /// Ustvari nov primerek <see cref="PortfolioChangedEventArgs"/>.
        /// </summary>
        /// <param name="action">Vrsta dejanja, ki je povzročilo spremembo.</param>
        /// <param name="affectedObject">Objekt, ki ga je sprememba prizadela.</param>
        public PortfolioChangedEventArgs(string action, object affectedObject)
        {
            Action = action;
            AffectedObject = affectedObject;
        }
    }
}
