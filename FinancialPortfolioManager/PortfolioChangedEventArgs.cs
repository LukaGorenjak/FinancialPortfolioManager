using System;

namespace FinancialPortfolioManager
{
    public class PortfolioChangedEventArgs : EventArgs
    {
        public string Action { get; }
        public object AffectedObject { get; }

        public PortfolioChangedEventArgs(string action, object affectedObject)
        {
            Action = action;
            AffectedObject = affectedObject;
        }
    }
}