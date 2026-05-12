namespace Es._2_22
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
            txtSearch = new TextBox();
            lstResults = new ListBox();
            tmrDebounce = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Inserisci un cognome";
            txtSearch.Size = new Size(267, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lstResults
            // 
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 15;
            lstResults.Location = new Point(12, 41);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(267, 394);
            lstResults.TabIndex = 1;
            // 
            // tmrDebounce
            // 
            tmrDebounce.Interval = 500;
            tmrDebounce.Tick += tmrDebounce_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 450);
            Controls.Add(lstResults);
            Controls.Add(txtSearch);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private ListBox lstResults;
        private System.Windows.Forms.Timer tmrDebounce;
    }
}
