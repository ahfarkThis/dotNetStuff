namespace QuoteExampleXML
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
            this.components = new System.ComponentModel.Container();
            this.RegQuote = new System.Windows.Forms.Button();
            this.symbolText = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbMsgs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // RegQuote
            // 
            this.RegQuote.Location = new System.Drawing.Point(261, 323);
            this.RegQuote.Name = "RegQuote";
            this.RegQuote.Size = new System.Drawing.Size(102, 41);
            this.RegQuote.TabIndex = 0;
            this.RegQuote.Text = "Get Quotes";
            this.RegQuote.UseVisualStyleBackColor = true;
            this.RegQuote.Click += new System.EventHandler(this.RegQuote_Click);
            // 
            // symbolText
            // 
            this.symbolText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.symbolText.Location = new System.Drawing.Point(72, 323);
            this.symbolText.Name = "symbolText";
            this.symbolText.Size = new System.Drawing.Size(140, 20);
            this.symbolText.TabIndex = 1;
            this.symbolText.Text = "BAC";
            // 
            // lbMsgs
            // 
            this.lbMsgs.BackColor = System.Drawing.SystemColors.Control;
            this.lbMsgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMsgs.FormattingEnabled = true;
            this.lbMsgs.ItemHeight = 20;
            this.lbMsgs.Location = new System.Drawing.Point(12, 12);
            this.lbMsgs.Name = "lbMsgs";
            this.lbMsgs.Size = new System.Drawing.Size(279, 284);
            this.lbMsgs.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(375, 376);
            this.Controls.Add(this.lbMsgs);
            this.Controls.Add(this.symbolText);
            this.Controls.Add(this.RegQuote);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegQuote;
        private System.Windows.Forms.TextBox symbolText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lbMsgs;

        public System.EventHandler lbMsgs_SelectedIndexChanged { get; set; }
    }
}

