namespace BomberJack
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
            this.buttonPlayerIndicator = new System.Windows.Forms.Button();
            this.Field = new System.Windows.Forms.GroupBox();
            this.labelNumberPlayers = new System.Windows.Forms.Label();
            this.numericUpDownPlayers = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlayerIndicator
            // 
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
            this.Field.Location = new System.Drawing.Point(12, 12);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(510, 401);
            this.Field.TabIndex = 2;
            this.Field.TabStop = false;
            this.Field.Text = "Playing Field";
            // 
            // labelNumberPlayers
            // 
            this.labelNumberPlayers.AutoSize = true;
            this.labelNumberPlayers.Location = new System.Drawing.Point(552, 44);
            this.labelNumberPlayers.Name = "labelNumberPlayers";
            this.labelNumberPlayers.Size = new System.Drawing.Size(105, 15);
            this.labelNumberPlayers.TabIndex = 3;
            this.labelNumberPlayers.Text = "Number of Players";
            // 
            // numericUpDownPlayers
            // 
            this.numericUpDownPlayers.Location = new System.Drawing.Point(690, 42);
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
            this.buttonStart.Location = new System.Drawing.Point(552, 76);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(189, 42);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 431);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownPlayers);
            this.Controls.Add(this.labelNumberPlayers);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.buttonPlayerIndicator);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonPlayerIndicator;
        private GroupBox Field;
        private Label labelNumberPlayers;
        private NumericUpDown numericUpDownPlayers;
        private Button buttonStart;
    }
}