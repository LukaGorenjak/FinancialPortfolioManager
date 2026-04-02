using System.Collections.Generic;
using System.Linq;
using FinancialPortfolioManager;

namespace FinancialPortfolioManager.Library
{
    /// <summary>
    /// Pomožna statična knjižnica z metodami za izračune portfelja.
    /// </summary>
    public static class PortfolioLibrary
    {
        /// <summary>
        /// Sešteje vrednosti vseh objektov, ki implementirajo <see cref="IValuable"/>.
        /// </summary>
        /// <param name="valuables">Zbirka naložb za izračun skupne vrednosti. Če je <c>null</c>, vrne 0.</param>
        /// <returns>Skupna vrednost vseh naložb kot <see cref="decimal"/>.</returns>
        public static decimal CalculateTotalValue(IEnumerable<IValuable> valuables)
        {
            if (valuables == null)
            {
                return 0m;
            }

            return valuables.Sum(v => v.GetValue());
        }
    }
}
