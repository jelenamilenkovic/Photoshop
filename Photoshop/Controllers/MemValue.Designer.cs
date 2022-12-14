namespace Photoshop
{
    partial class MemValue
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
            this.memv = new System.Windows.Forms.Label();
            this.nummb = new System.Windows.Forms.NumericUpDown();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nummb)).BeginInit();
            this.SuspendLayout();
            // 
            // memv
            // 
            this.memv.AutoSize = true;
            this.memv.Location = new System.Drawing.Point(98, 90);
            this.memv.Name = "memv";
            this.memv.Size = new System.Drawing.Size(110, 13);
            this.memv.TabIndex = 1;
            this.memv.Text = "Max value of memory:";
            // 
            // nummb
            // 
            this.nummb.Location = new System.Drawing.Point(252, 83);
            this.nummb.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nummb.Name = "nummb";
            this.nummb.Size = new System.Drawing.Size(100, 20);
            this.nummb.TabIndex = 2;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(229, 166);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(82, 27);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(101, 166);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(82, 27);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // MemValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 271);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.nummb);
            this.Controls.Add(this.memv);
            this.Name = "MemValue";
            this.Text = "MemValue";
            ((System.ComponentModel.ISupportInitialize)(this.nummb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label memv;
        private System.Windows.Forms.NumericUpDown nummb;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}