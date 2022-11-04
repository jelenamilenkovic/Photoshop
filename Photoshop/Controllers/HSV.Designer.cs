namespace Photoshop
{
    partial class HSV
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
            this.newH = new System.Windows.Forms.NumericUpDown();
            this.newS = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.newH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newS)).BeginInit();
            this.SuspendLayout();
            // 
            // newH
            // 
            this.newH.Location = new System.Drawing.Point(245, 46);
            this.newH.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.newH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.newH.Name = "newH";
            this.newH.Size = new System.Drawing.Size(109, 20);
            this.newH.TabIndex = 0;
            // 
            // newS
            // 
            this.newS.DecimalPlaces = 1;
            this.newS.Location = new System.Drawing.Point(245, 103);
            this.newS.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.newS.Name = "newS";
            this.newS.Size = new System.Drawing.Size(109, 20);
            this.newS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "newHue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "newSaturation";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(293, 158);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(95, 25);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(123, 158);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(95, 25);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // HSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 219);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newS);
            this.Controls.Add(this.newH);
            this.Name = "HSV";
            this.Text = "HSV";
            ((System.ComponentModel.ISupportInitialize)(this.newH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown newH;
        public System.Windows.Forms.NumericUpDown newS;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}