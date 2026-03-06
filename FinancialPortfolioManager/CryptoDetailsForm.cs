using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinancialPortfolioManager
{
    public class CryptoDetailsForm : Form
    {
        private readonly TextBox blockchainTextBox;
        private readonly TextBox stakingTextBox;
        private readonly CheckBox stablecoinCheckBox;
        private readonly Button okButton;
        private readonly Button cancelButton;

        public string Blockchain => blockchainTextBox.Text.Trim();
        public bool IsStablecoin => stablecoinCheckBox.Checked;

        public decimal StakingPercent
        {
            get
            {
                if (decimal.TryParse(stakingTextBox.Text, out var value) && value >= 0)
                    return value;
                return 0m;
            }
        }

        public CryptoDetailsForm(string blockchain, bool isStablecoin, decimal stakingPercent)
        {
            Text = "Crypto Details";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(320, 180);

            var blockchainLabel = new Label
            {
                Text = "Blockchain:",
                Location = new Point(10, 20),
                AutoSize = true
            };
            blockchainTextBox = new TextBox
            {
                Location = new Point(110, 17),
                Size = new Size(180, 23),
                Text = blockchain
            };

            var stakingLabel = new Label
            {
                Text = "Staking %:",
                Location = new Point(10, 55),
                AutoSize = true
            };
            stakingTextBox = new TextBox
            {
                Location = new Point(110, 52),
                Size = new Size(60, 23),
                Text = stakingPercent.ToString("N2")
            };

            stablecoinCheckBox = new CheckBox
            {
                Text = "Stablecoin",
                Location = new Point(110, 85),
                AutoSize = true,
                Checked = isStablecoin
            };

            okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(110, 120),
                Size = new Size(75, 25)
            };

            cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(215, 120),
                Size = new Size(75, 25)
            };

            Controls.Add(blockchainLabel);
            Controls.Add(blockchainTextBox);
            Controls.Add(stakingLabel);
            Controls.Add(stakingTextBox);
            Controls.Add(stablecoinCheckBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);

            AcceptButton = okButton;
            CancelButton = cancelButton;
        }
    }
}

