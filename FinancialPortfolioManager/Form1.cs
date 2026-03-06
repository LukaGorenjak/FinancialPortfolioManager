using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace FinancialPortfolioManager
{
    public partial class Form1 : Form
    {
        public Portfolio portfolio1 = new Portfolio();

        private readonly Dictionary<string, StockMetadata> stockMetadata =
            new(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, CryptoMetadata> cryptoMetadata =
            new(StringComparer.OrdinalIgnoreCase);

        private class StockMetadata
        {
            public string Exchange { get; set; } = string.Empty;
            public string Sector { get; set; } = string.Empty;
            public bool IsEtf { get; set; }
            public decimal DividendYield { get; set; }
        }

        private class CryptoMetadata
        {
            public string Blockchain { get; set; } = string.Empty;
            public bool IsStablecoin { get; set; }
            public decimal StakingYield { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            timer1.Start();

            portfolio1.PortfolioChanged += Portfolio1_PortfolioChanged;
        }
        
        private void Portfolio1_PortfolioChanged(object sender, PortfolioChangedEventArgs e)
        {
            MessageBox.Show($"Portfolio action: {e.Action}\nObject: {e.AffectedObject}", "Portfolio Changed");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StockDisplayLabel_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Portfolio.ChangeCurrency();
            portfolioValueLabel.Text = portfolio1.GetTotalValue().ToString("N2") + " " + Portfolio.currency;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an investment type!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tickerTextBox.Text) ||
                string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(priceTextBox.Text) ||
                string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (!decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Invalid price");
                return;
            }

            if (!decimal.TryParse(amountTextBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Invalid amount");
                return;
            }

            if (amount < Investment.MIN_INVESTMENT_AMOUNT)
            {
                MessageBox.Show($"Amount must be at least {Investment.MIN_INVESTMENT_AMOUNT}.");
                return;
            }

            decimal totalCost = price * amount;

            if (!portfolio1.Withdraw(totalCost))
            {
                MessageBox.Show("Not enough cash!");
                return;
            }

            Investment investment;
            string typeString = comboBox1.SelectedItem.ToString();
            string ticker = tickerTextBox.Text.Trim().ToUpper();

            if (typeString == "Stock")
            {
                var stock = new StockInvestment(
                    ticker,
                    nameTextBox.Text,
                    amount,
                    price
                );

                if (stockMetadata.TryGetValue(ticker, out var meta))
                {
                    stock.Exchange = meta.Exchange;
                    stock.Sector = meta.Sector;
                    stock.IsEtf = meta.IsEtf;
                    stock.DividendYield = meta.DividendYield;
                }

                investment = stock;
            }
            else
            {
                var crypto = new CryptoInvestment(
                    ticker,
                    nameTextBox.Text,
                    amount,
                    price
                );

                if (cryptoMetadata.TryGetValue(ticker, out var meta))
                {
                    crypto.Blockchain = meta.Blockchain;
                    crypto.IsStablecoin = meta.IsStablecoin;
                    crypto.StakingYield = meta.StakingYield;
                }

                investment = crypto;
            }

            var tx = new Transaction(
                tickerTextBox.Text.Trim().ToUpper(),
                nameTextBox.Text,
                amount,
                price,
                investment.Type
            )
            {
                IsBuy = true
            };

            portfolio1.AddTransaction(tx, true);
            portfolio1.AddInvestment(investment);

            UpdateInvestmentsList();
            UpdateTransactionsList();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            portfolioValueLabel.Text =
                portfolio1.GetTotalValue().ToString("N2") + " " + Portfolio.currency;

            UpdateAllocationDisplay();
            UpdateInvestmentsList();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void UpdateInvestmentsList()
        {
            investmentsListBox.Items.Clear();

            investmentsListBox.Items.Add(
                $"Cash: {portfolio1.CashBalance:N2} {Portfolio.currency}"
            );

            var investments = portfolio1.GetInvestments();
            for (int i = 0; i < investments.Count; i++)
            {
                var inv = portfolio1[i];
                investmentsListBox.Items.Add(
                    $"{inv.Ticker} | {inv.Amount} | Avg {inv.BuyPrice:N2} {Portfolio.currency}"
                );
            }
        }

        private void UpdateTransactionsList()
        {
            transactionsListBox.Items.Clear();

            foreach (var tx in portfolio1.GetTransactions())
            {
                string action = tx.IsBuy ? "BUY" : "SELL";
                transactionsListBox.Items.Add(
                    $"{tx.Date:dd.MM HH:mm} | {action} {tx.Ticker} x{tx.Amount} @ {tx.Price:N2} ({tx.TotalValue:N2})"
                );
            }
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            portfolio1.Deposit(numericUpDownAmount1.Value);
            UpdateInvestmentsList();
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            if (!portfolio1.Withdraw(numericUpDownAmount1.Value))
                MessageBox.Show("Not enough cash!");

            UpdateInvestmentsList();
        }

        private void UpdateAllocationDisplay()
        {
            label1.Text =
                $"{portfolio1.GetPercentageByType(InvestmentType.Stock):N1}%";

            label2.Text =
                $"{portfolio1.GetPercentageByType(InvestmentType.Crypto):N1}%";

            label3.Text =
                $"{portfolio1.GetPercentageByType(InvestmentType.Cash):N1}%";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Black)
            {
                this.BackColor = Color.White;
                groupBox1.BackColor = Color.White;
                groupBox2.BackColor = Color.White;
                groupBox3.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.Black;
                groupBox1.ForeColor = Color.Black;
                groupBox2.ForeColor = Color.Black;
                groupBox3.ForeColor = Color.Black;
            }
        }

        private void tickerTextBox_Leave(object sender, EventArgs e)
        {
            // Metadata is now edited via the Details dialog, so this handler is left empty.
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an investment type first.");
                return;
            }

            string ticker = tickerTextBox.Text.Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(ticker))
            {
                MessageBox.Show("Please enter a ticker first.");
                return;
            }

            string typeString = comboBox1.SelectedItem.ToString();

            if (typeString == "Stock")
            {
                stockMetadata.TryGetValue(ticker, out var existing);

                using (var dlg = new StockDetailsForm(
                           existing?.Exchange ?? string.Empty,
                           existing?.Sector ?? string.Empty,
                           existing?.IsEtf ?? false,
                           existing != null ? existing.DividendYield * 100m : 0m))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        stockMetadata[ticker] = new StockMetadata
                        {
                            Exchange = dlg.Exchange,
                            Sector = dlg.Sector,
                            IsEtf = dlg.IsEtf,
                            DividendYield = dlg.DividendYieldPercent / 100m
                        };
                    }
                }
            }
            else if (typeString == "Crypto")
            {
                cryptoMetadata.TryGetValue(ticker, out var existing);

                using (var dlg = new CryptoDetailsForm(
                           existing?.Blockchain ?? string.Empty,
                           existing?.IsStablecoin ?? false,
                           existing != null ? existing.StakingYield * 100m : 0m))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        cryptoMetadata[ticker] = new CryptoMetadata
                        {
                            Blockchain = dlg.Blockchain,
                            IsStablecoin = dlg.IsStablecoin,
                            StakingYield = dlg.StakingPercent / 100m
                        };
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an investment type!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tickerTextBox.Text) ||
                string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(priceTextBox.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (!decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Invalid price");
                return;
            }

            if (!decimal.TryParse(amountTextBox.Text, out decimal amountToSell) || amountToSell <= 0)
            {
                MessageBox.Show("Invalid amount to sell.");
                return;
            }
            string ticker = tickerTextBox.Text.Trim().ToUpper();
            string name = nameTextBox.Text.Trim();
            string typeString = comboBox1.SelectedItem.ToString();

            var investment = portfolio1[ticker];

            if (investment == null || investment.Name != name || investment.Type.ToString() != typeString)
            {
                MessageBox.Show("You do not own this investment.");
                return;
            }

            const decimal tolerance = 0.00001m;

            if (amountToSell <= 0 || amountToSell - investment.Amount > tolerance)
            {
                MessageBox.Show("Invalid amount to sell.");
                return;
            }

            if (Math.Abs(investment.Amount - amountToSell) < tolerance)
            {
                amountToSell = investment.Amount;
                portfolio1.RemoveInvestment(investment);
            }
            else
            {
                investment.Amount -= amountToSell;
            }

            decimal totalProceeds = price * amountToSell;
            portfolio1.Deposit(totalProceeds);

            var tx = new Transaction(ticker, name, amountToSell, price, investment.Type)
            {
                IsBuy = false
            };
            portfolio1.AddTransaction(tx, false);

            UpdateInvestmentsList();
            UpdateTransactionsList();
        }

        private void transactionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
