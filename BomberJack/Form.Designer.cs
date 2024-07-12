namespace BomberJack
{
    partial class Form
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
            this.buttonPlayerIndicator = new System.Windows.Forms.Button();
            this.Field = new System.Windows.Forms.GroupBox();
            this.labelNumberPlayers = new System.Windows.Forms.Label();
            this.numericUpDownPlayers = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.labelPlayer3Score = new System.Windows.Forms.Label();
            this.labelPlayer4Score = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFieldSize = new System.Windows.Forms.Label();
            this.numericUpDownFieldSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlayerIndicator
            // 
            this.buttonPlayerIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlayerIndicator.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPlayerIndicator.Location = new System.Drawing.Point(552, 272);
            this.buttonPlayerIndicator.Name = "buttonPlayerIndicator";
            this.buttonPlayerIndicator.Size = new System.Drawing.Size(189, 141);
            this.buttonPlayerIndicator.TabIndex = 0;
            this.buttonPlayerIndicator.Text = "button1";
            this.buttonPlayerIndicator.UseVisualStyleBackColor = true;
            this.buttonPlayerIndicator.Visible = false;
            this.buttonPlayerIndicator.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPlayerIndicator);
            // 
            // Field
            // 
            this.Field.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Field.Location = new System.Drawing.Point(12, 12);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(510, 401);
            this.Field.TabIndex = 2;
            this.Field.TabStop = false;
            this.Field.Text = "Playing Field";
            // 
            // labelNumberPlayers
            // 
            this.labelNumberPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumberPlayers.AutoSize = true;
            this.labelNumberPlayers.Location = new System.Drawing.Point(552, 21);
            this.labelNumberPlayers.Name = "labelNumberPlayers";
            this.labelNumberPlayers.Size = new System.Drawing.Size(105, 15);
            this.labelNumberPlayers.TabIndex = 3;
            this.labelNumberPlayers.Text = "Number of Players";
            // 
            // numericUpDownPlayers
            // 
            this.numericUpDownPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPlayers.Location = new System.Drawing.Point(690, 19);
            this.numericUpDownPlayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPlayers.Name = "numericUpDownPlayers";
            this.numericUpDownPlayers.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownPlayers.TabIndex = 4;
            this.numericUpDownPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(554, 92);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(189, 42);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Location = new System.Drawing.Point(554, 158);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(51, 15);
            this.labelPlayer1Score.TabIndex = 6;
            this.labelPlayer1Score.Text = "Player 1:";
            this.labelPlayer1Score.Visible = false;
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Location = new System.Drawing.Point(554, 183);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(51, 15);
            this.labelPlayer2Score.TabIndex = 7;
            this.labelPlayer2Score.Text = "Player 2:";
            this.labelPlayer2Score.Visible = false;
            // 
            // labelPlayer3Score
            // 
            this.labelPlayer3Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer3Score.AutoSize = true;
            this.labelPlayer3Score.Location = new System.Drawing.Point(554, 208);
            this.labelPlayer3Score.Name = "labelPlayer3Score";
            this.labelPlayer3Score.Size = new System.Drawing.Size(51, 15);
            this.labelPlayer3Score.TabIndex = 8;
            this.labelPlayer3Score.Text = "Player 3:";
            this.labelPlayer3Score.Visible = false;
            // 
            // labelPlayer4Score
            // 
            this.labelPlayer4Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer4Score.AutoSize = true;
            this.labelPlayer4Score.Location = new System.Drawing.Point(554, 234);
            this.labelPlayer4Score.Name = "labelPlayer4Score";
            this.labelPlayer4Score.Size = new System.Drawing.Size(51, 15);
            this.labelPlayer4Score.TabIndex = 9;
            this.labelPlayer4Score.Text = "Player 4:";
            this.labelPlayer4Score.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(611, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = " ";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(611, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = " ";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(611, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = " ";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(611, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = " ";
            this.label4.Visible = false;
            // 
            // labelFieldSize
            // 
            this.labelFieldSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFieldSize.AutoSize = true;
            this.labelFieldSize.Location = new System.Drawing.Point(554, 56);
            this.labelFieldSize.Name = "labelFieldSize";
            this.labelFieldSize.Size = new System.Drawing.Size(54, 15);
            this.labelFieldSize.TabIndex = 14;
            this.labelFieldSize.Text = "Field size";
            // 
            // numericUpDownFieldSize
            // 
            this.numericUpDownFieldSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFieldSize.Location = new System.Drawing.Point(690, 54);
            this.numericUpDownFieldSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownFieldSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownFieldSize.Name = "numericUpDownFieldSize";
            this.numericUpDownFieldSize.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownFieldSize.TabIndex = 15;
            this.numericUpDownFieldSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 431);
            this.Controls.Add(this.numericUpDownFieldSize);
            this.Controls.Add(this.labelFieldSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPlayer4Score);
            this.Controls.Add(this.labelPlayer3Score);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownPlayers);
            this.Controls.Add(this.labelNumberPlayers);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.buttonPlayerIndicator);
            this.Name = "Form";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonPlayerIndicator;
        private GroupBox Field;
        private Label labelNumberPlayers;
        private NumericUpDown numericUpDownPlayers;
        private Button buttonStart;
        private Label labelPlayer1Score;
        private Label labelPlayer2Score;
        private Label labelPlayer3Score;
        private Label labelPlayer4Score;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelFieldSize;
        private NumericUpDown numericUpDownFieldSize;
    }
}