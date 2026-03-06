namespace FinancialPortfolioManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            portfolioValueLabel = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            MoneyDisplayLabel = new Label();
            CryptoDisplayLabel = new Label();
            StockDisplayLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            groupBox2 = new GroupBox();
            investmentsListBox = new ListBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            label10 = new Label();
            amountTextBox = new TextBox();
            numericUpDownAmount1 = new NumericUpDown();
            detailsButton = new Button();
            withdrawButton = new Button();
            label8 = new Label();
            nameTextBox = new TextBox();
            comboBox1 = new ComboBox();
            depositButton = new Button();
            label7 = new Label();
            label6 = new Label();
            tickerTextBox = new TextBox();
            button2 = new Button();
            button1 = new Button();
            priceTextBox = new TextBox();
            button5 = new Button();
            button6 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            transactionsListBox = new ListBox();
            label9 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(portfolioValueLabel);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(MoneyDisplayLabel);
            groupBox1.Controls.Add(CryptoDisplayLabel);
            groupBox1.Controls.Add(StockDisplayLabel);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(459, 225);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // portfolioValueLabel
            // 
            portfolioValueLabel.AutoSize = true;
            portfolioValueLabel.Location = new Point(108, 105);
            portfolioValueLabel.Name = "portfolioValueLabel";
            portfolioValueLabel.Size = new Size(17, 20);
            portfolioValueLabel.TabIndex = 9;
            portfolioValueLabel.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(98, 75);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 8;
            label5.Text = "Portfolio Value";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(238, 190);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 7;
            label3.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 123);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 6;
            label2.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(238, 56);
            label1.Name = "label1";
            label1.Size = new Size(17, 20);
            label1.TabIndex = 5;
            label1.Text = "0";
            // 
            // MoneyDisplayLabel
            // 
            MoneyDisplayLabel.AutoSize = true;
            MoneyDisplayLabel.Location = new Point(238, 159);
            MoneyDisplayLabel.Name = "MoneyDisplayLabel";
            MoneyDisplayLabel.Size = new Size(40, 20);
            MoneyDisplayLabel.TabIndex = 4;
            MoneyDisplayLabel.Text = "Cash";
            // 
            // CryptoDisplayLabel
            // 
            CryptoDisplayLabel.AutoSize = true;
            CryptoDisplayLabel.Location = new Point(238, 92);
            CryptoDisplayLabel.Name = "CryptoDisplayLabel";
            CryptoDisplayLabel.Size = new Size(53, 20);
            CryptoDisplayLabel.TabIndex = 3;
            CryptoDisplayLabel.Text = "Crypto";
            // 
            // StockDisplayLabel
            // 
            StockDisplayLabel.AutoSize = true;
            StockDisplayLabel.Location = new Point(238, 27);
            StockDisplayLabel.Name = "StockDisplayLabel";
            StockDisplayLabel.Size = new Size(51, 20);
            StockDisplayLabel.TabIndex = 2;
            StockDisplayLabel.Text = "Stocks";
            StockDisplayLabel.Click += StockDisplayLabel_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(investmentsListBox);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 243);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(459, 300);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // investmentsListBox
            // 
            investmentsListBox.FormattingEnabled = true;
            investmentsListBox.Location = new Point(6, 60);
            investmentsListBox.Name = "investmentsListBox";
            investmentsListBox.Size = new Size(422, 224);
            investmentsListBox.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(6, 25);
            label4.Name = "label4";
            label4.Size = new Size(88, 28);
            label4.TabIndex = 1;
            label4.Text = "Portfolio";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(amountTextBox);
            groupBox3.Controls.Add(numericUpDownAmount1);
            groupBox3.Controls.Add(detailsButton);
            groupBox3.Controls.Add(withdrawButton);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(nameTextBox);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(depositButton);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(tickerTextBox);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(priceTextBox);
            groupBox3.Location = new Point(491, 243);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(421, 300);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(250, 210);
            label10.Name = "label10";
            label10.Size = new Size(62, 20);
            label10.TabIndex = 14;
            label10.Text = "Amount";
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(318, 207);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(54, 27);
            amountTextBox.TabIndex = 13;
            // 
            // numericUpDownAmount1
            // 
            numericUpDownAmount1.Location = new Point(139, 73);
            numericUpDownAmount1.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            numericUpDownAmount1.Name = "numericUpDownAmount1";
            numericUpDownAmount1.Size = new Size(150, 27);
            numericUpDownAmount1.TabIndex = 12;
            // 
            // detailsButton
            // 
            detailsButton.Location = new Point(42, 240);
            detailsButton.Name = "detailsButton";
            detailsButton.Size = new Size(330, 27);
            detailsButton.TabIndex = 23;
            detailsButton.Text = "Details...";
            detailsButton.UseVisualStyleBackColor = true;
            detailsButton.Click += detailsButton_Click;
            // 
            // withdrawButton
            // 
            withdrawButton.Location = new Point(226, 39);
            withdrawButton.Name = "withdrawButton";
            withdrawButton.Size = new Size(146, 28);
            withdrawButton.TabIndex = 6;
            withdrawButton.Text = "Withdraw";
            withdrawButton.UseVisualStyleBackColor = true;
            withdrawButton.Click += withdrawButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(175, 177);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 11;
            label8.Text = "Name";
            label8.Click += label8_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(226, 174);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(86, 27);
            nameTextBox.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Stock", "Crypto" });
            comboBox1.Location = new Point(318, 173);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(54, 28);
            comboBox1.TabIndex = 9;
            // 
            // depositButton
            // 
            depositButton.Location = new Point(42, 39);
            depositButton.Name = "depositButton";
            depositButton.Size = new Size(159, 28);
            depositButton.TabIndex = 4;
            depositButton.Text = "Deposit";
            depositButton.UseVisualStyleBackColor = true;
            depositButton.Click += depositButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(49, 207);
            label7.Name = "label7";
            label7.Size = new Size(41, 20);
            label7.TabIndex = 8;
            label7.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 177);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 7;
            label6.Text = "Ticker";
            // 
            // tickerTextBox
            // 
            tickerTextBox.Location = new Point(96, 174);
            tickerTextBox.Name = "tickerTextBox";
            tickerTextBox.Size = new Size(73, 27);
            tickerTextBox.TabIndex = 6;
            tickerTextBox.Leave += tickerTextBox_Leave;
            // 
            // button2
            // 
            button2.Location = new Point(226, 139);
            button2.Name = "button2";
            button2.Size = new Size(146, 29);
            button2.TabIndex = 5;
            button2.Text = "SELL";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(42, 139);
            button1.Name = "button1";
            button1.Size = new Size(159, 29);
            button1.TabIndex = 2;
            button1.Text = "BUY";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(96, 207);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(148, 27);
            priceTextBox.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new Point(650, 17);
            button5.Name = "button5";
            button5.Size = new Size(140, 29);
            button5.TabIndex = 5;
            button5.Text = "Change Currency";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(805, 17);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 3;
            button6.Text = "Light/Dark";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // transactionsListBox
            // 
            transactionsListBox.FormattingEnabled = true;
            transactionsListBox.Location = new Point(491, 52);
            transactionsListBox.Name = "transactionsListBox";
            transactionsListBox.Size = new Size(421, 184);
            transactionsListBox.TabIndex = 6;
            transactionsListBox.SelectedIndexChanged += transactionsListBox_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(491, 18);
            label9.Name = "label9";
            label9.Size = new Size(118, 28);
            label9.TabIndex = 7;
            label9.Text = "Transactions";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(924, 555);
            Controls.Add(label9);
            Controls.Add(transactionsListBox);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximumSize = new Size(942, 602);
            MinimumSize = new Size(942, 602);
            Name = "Form1";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "FinancialPortfolioManager";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label MoneyDisplayLabel;
        private Label CryptoDisplayLabel;
        private Label StockDisplayLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private GroupBox groupBox2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private GroupBox groupBox3;
        private Button button1;
        private TextBox priceTextBox;
        private Button button2;
        private Button depositButton;
        private Button button5;
        private Button button6;
        private Button withdrawButton;
        private Label label7;
        private Label label6;
        private TextBox tickerTextBox;
        private ComboBox comboBox1;
        private System.Windows.Forms.Timer timer1;
        private Label portfolioValueLabel;
        private Label label8;
        private TextBox nameTextBox;
        private ListBox investmentsListBox;
        private NumericUpDown numericUpDownAmount1;
        private ListBox transactionsListBox;
        private Label label9;
        private Label label10;
        private TextBox amountTextBox;
        private Button detailsButton;
    }
}
