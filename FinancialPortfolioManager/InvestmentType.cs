using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioManager
{
    /// <summary>
    /// Definira vrsto naložbe, ki jo portfelj podpira.
    /// </summary>
    public enum InvestmentType
    {
        /// <summary>Delniška naložba ali ETF.</summary>
        Stock,
        /// <summary>Kriptovalutna naložba.</summary>
        Crypto,
        /// <summary>Gotovina v portfelju.</summary>
        Cash
    }
}
