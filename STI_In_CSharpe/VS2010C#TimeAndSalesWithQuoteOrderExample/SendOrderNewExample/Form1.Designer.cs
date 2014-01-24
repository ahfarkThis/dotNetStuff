namespace TimeAndSalesWithQuoteOrderExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.symbolText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.accountText = new System.Windows.Forms.TextBox();
            this.qtyText = new System.Windows.Forms.TextBox();
            this.destText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buyButton = new System.Windows.Forms.Button();
            this.sellButton = new System.Windows.Forms.Button();
            this.lbMsgs = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tsListBox = new System.Windows.Forms.ListBox();
            this.quoteLabel = new System.Windows.Forms.Label();
            this.askLabel = new System.Windows.Forms.Label();
            this.bidLabel = new System.Windows.Forms.Label();
            this.bSizeLabel = new System.Windows.Forms.Label();
            this.aSizeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SYMBOL:";
            // 
            // symbolText
            // 
            this.symbolText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbolText.Location = new System.Drawing.Point(105, 9);
            this.symbolText.Name = "symbolText";
            this.symbolText.Size = new System.Drawing.Size(100, 26);
            this.symbolText.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get Quote";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // accountText
            // 
            this.accountText.Location = new System.Drawing.Point(105, 114);
            this.accountText.Name = "accountText";
            this.accountText.Size = new System.Drawing.Size(100, 20);
            this.accountText.TabIndex = 11;
            // 
            // qtyText
            // 
            this.qtyText.Location = new System.Drawing.Point(105, 151);
            this.qtyText.Name = "qtyText";
            this.qtyText.Size = new System.Drawing.Size(100, 20);
            this.qtyText.TabIndex = 12;
            // 
            // destText
            // 
            this.destText.Location = new System.Drawing.Point(105, 186);
            this.destText.Name = "destText";
            this.destText.Size = new System.Drawing.Size(100, 20);
            this.destText.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "ACCOUNT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "QUANTITY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "DESTINATION";
            // 
            // buyButton
            // 
            this.buyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyButton.Location = new System.Drawing.Point(288, 136);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(103, 92);
            this.buyButton.TabIndex = 17;
            this.buyButton.Text = "BUY@Bid";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // sellButton
            // 
            this.sellButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellButton.Location = new System.Drawing.Point(504, 136);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(103, 92);
            this.sellButton.TabIndex = 18;
            this.sellButton.Text = "SELL@Ask";
            this.sellButton.UseVisualStyleBackColor = true;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
            // 
            // lbMsgs
            // 
            this.lbMsgs.FormattingEnabled = true;
            this.lbMsgs.Location = new System.Drawing.Point(16, 269);
            this.lbMsgs.Name = "lbMsgs";
            this.lbMsgs.Size = new System.Drawing.Size(189, 121);
            this.lbMsgs.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(782, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Time && Sales";
            // 
            // tsListBox
            // 
            this.tsListBox.FormattingEnabled = true;
            this.tsListBox.Location = new System.Drawing.Point(727, 41);
            this.tsListBox.Name = "tsListBox";
            this.tsListBox.Size = new System.Drawing.Size(194, 329);
            this.tsListBox.TabIndex = 22;
            // 
            // quoteLabel
            // 
            this.quoteLabel.AutoSize = true;
            this.quoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quoteLabel.ForeColor = System.Drawing.Color.Blue;
            this.quoteLabel.Location = new System.Drawing.Point(178, 42);
            this.quoteLabel.Name = "quoteLabel";
            this.quoteLabel.Size = new System.Drawing.Size(70, 31);
            this.quoteLabel.TabIndex = 5;
            this.quoteLabel.Text = "Last";
            // 
            // askLabel
            // 
            this.askLabel.AutoSize = true;
            this.askLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.askLabel.ForeColor = System.Drawing.Color.GreenYellow;
            this.askLabel.Location = new System.Drawing.Point(291, 48);
            this.askLabel.Name = "askLabel";
            this.askLabel.Size = new System.Drawing.Size(51, 25);
            this.askLabel.TabIndex = 7;
            this.askLabel.Text = "Ask";
            // 
            // bidLabel
            // 
            this.bidLabel.AutoSize = true;
            this.bidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bidLabel.ForeColor = System.Drawing.Color.Red;
            this.bidLabel.Location = new System.Drawing.Point(84, 48);
            this.bidLabel.Name = "bidLabel";
            this.bidLabel.Size = new System.Drawing.Size(46, 25);
            this.bidLabel.TabIndex = 8;
            this.bidLabel.Text = "Bid";
            // 
            // bSizeLabel
            // 
            this.bSizeLabel.AutoSize = true;
            this.bSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSizeLabel.Location = new System.Drawing.Point(9, 53);
            this.bSizeLabel.Name = "bSizeLabel";
            this.bSizeLabel.Size = new System.Drawing.Size(63, 20);
            this.bSizeLabel.TabIndex = 9;
            this.bSizeLabel.Text = "BidSize";
            // 
            // aSizeLabel
            // 
            this.aSizeLabel.AutoSize = true;
            this.aSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aSizeLabel.Location = new System.Drawing.Point(401, 53);
            this.aSizeLabel.Name = "aSizeLabel";
            this.aSizeLabel.Size = new System.Drawing.Size(67, 20);
            this.aSizeLabel.TabIndex = 10;
            this.aSizeLabel.Text = "AskSize";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.aSizeLabel);
            this.groupBox1.Controls.Add(this.bSizeLabel);
            this.groupBox1.Controls.Add(this.bidLabel);
            this.groupBox1.Controls.Add(this.askLabel);
            this.groupBox1.Controls.Add(this.quoteLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(236, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 107);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quote Monitor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Client Order ID Display";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 426);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbMsgs);
            this.Controls.Add(this.sellButton);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.destText);
            this.Controls.Add(this.qtyText);
            this.Controls.Add(this.accountText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.symbolText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbolText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox accountText;
        private System.Windows.Forms.TextBox qtyText;
        private System.Windows.Forms.TextBox destText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.ListBox lbMsgs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox tsListBox;
        private System.Windows.Forms.Label quoteLabel;
        private System.Windows.Forms.Label askLabel;
        private System.Windows.Forms.Label bidLabel;
        private System.Windows.Forms.Label bSizeLabel;
        private System.Windows.Forms.Label aSizeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
    }
}

