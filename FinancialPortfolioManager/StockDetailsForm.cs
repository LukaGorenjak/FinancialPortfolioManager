using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinancialPortfolioManager
{
    public class StockDetailsForm : Form
    {
        private readonly TextBox exchangeTextBox;
        private readonly TextBox sectorTextBox;
        private readonly TextBox dividendTextBox;
        private readonly CheckBox etfCheckBox;
        private readonly Button okButton;
        private readonly Button cancelButton;

        public string Exchange => exchangeTextBox.Text.Trim();
        public string Sector => sectorTextBox.Text.Trim();
        public bool IsEtf => etfCheckBox.Checked;

        public decimal DividendYieldPercent
        {
            get
            {
                if (decimal.TryParse(dividendTextBox.Text, out var value) && value >= 0)
                    return value;
                return 0m;
            }
        }

        public StockDetailsForm(string exchange, string sector, bool isEtf, decimal dividendPercent)
        {
            Text = "Stock Details";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(320, 200);

            var exchangeLabel = new Label
            {
                Text = "Exchange:",
                Location = new Point(10, 20),
                AutoSize = true
            };
            exchangeTextBox = new TextBox
            {
                Location = new Point(110, 17),
                Size = new Size(180, 23),
                Text = exchange
            };

            var sectorLabel = new Label
            {
                Text = "Sector:",
                Location = new Point(10, 55),
                AutoSize = true
            };
            sectorTextBox = new TextBox
            {
                Location = new Point(110, 52),
                Size = new Size(180, 23),
                Text = sector
            };

            var dividendLabel = new Label
            {
                Text = "Dividend %:",
                Location = new Point(10, 90),
                AutoSize = true
            };
            dividendTextBox = new TextBox
            {
                Location = new Point(110, 87),
                Size = new Size(60, 23),
                Text = dividendPercent.ToString("N2")
            };

            etfCheckBox = new CheckBox
            {
                Text = "Is ETF",
                Location = new Point(110, 120),
                AutoSize = true,
                Checked = isEtf
            };

            okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(110, 150),
                Size = new Size(75, 25)
            };

            cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(215, 150),
                Size = new Size(75, 25)
            };

            Controls.Add(exchangeLabel);
            Controls.Add(exchangeTextBox);
            Controls.Add(sectorLabel);
            Controls.Add(sectorTextBox);
            Controls.Add(dividendLabel);
            Controls.Add(dividendTextBox);
            Controls.Add(etfCheckBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);

            AcceptButton = okButton;
            CancelButton = cancelButton;
        }
    }
}

