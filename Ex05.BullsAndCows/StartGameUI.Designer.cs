namespace Ex05.BullsAndCowsUI
{
    partial class StartGameUI
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
            this.buttonNumberOfGuesses = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNumberOfGuesses
            // 
            this.buttonNumberOfGuesses.Location = new System.Drawing.Point(12, 12);
            this.buttonNumberOfGuesses.Name = "buttonNumberOfGuesses";
            this.buttonNumberOfGuesses.Size = new System.Drawing.Size(205, 23);
            this.buttonNumberOfGuesses.TabIndex = 0;
            this.buttonNumberOfGuesses.Text = "Number of Chances: 4";
            this.buttonNumberOfGuesses.UseVisualStyleBackColor = true;
            this.buttonNumberOfGuesses.Click += new System.EventHandler(this.buttonNumberOfGuesses_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(142, 124);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // StartGameUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 159);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonNumberOfGuesses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartGameUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bull And Cows";
            this.Load += new System.EventHandler(this.StartGameUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNumberOfGuesses;
        private System.Windows.Forms.Button buttonStart;
    }
}