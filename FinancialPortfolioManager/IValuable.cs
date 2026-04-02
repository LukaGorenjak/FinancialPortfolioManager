using System;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Vmesnik za objekte, ki imajo izmerljivo vrednost.
    /// </summary>
    public interface IValuable
    {
        /// <summary>
        /// Vrne trenutno vrednost naložbe.
        /// </summary>
        /// <returns>Trenutna tržna vrednost kot <see cref="decimal"/>.</returns>
        decimal GetValue();

        /// <summary>
        /// Kratki povzetek naložbe (simbol, ime, količina, cena nakupa, vrsta).
        /// </summary>
        string Summary { get; }
    }
}
