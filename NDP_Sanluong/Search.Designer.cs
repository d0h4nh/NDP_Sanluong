namespace NDP_Sanluong
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.btnSearchC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCom = new System.Windows.Forms.TextBox();
            this.dataCusname = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataCusname)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchC
            // 
            this.btnSearchC.Location = new System.Drawing.Point(880, 27);
            this.btnSearchC.Name = "btnSearchC";
            this.btnSearchC.Size = new System.Drawing.Size(75, 23);
            this.btnSearchC.TabIndex = 0;
            this.btnSearchC.Text = "Search";
            this.btnSearchC.UseVisualStyleBackColor = true;
            this.btnSearchC.Click += new System.EventHandler(this.btnSearchC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company name";
            // 
            // txtCom
            // 
            this.txtCom.Location = new System.Drawing.Point(100, 28);
            this.txtCom.Name = "txtCom";
            this.txtCom.Size = new System.Drawing.Size(774, 20);
            this.txtCom.TabIndex = 2;
            // 
            // dataCusname
            // 
            this.dataCusname.AllowUserToAddRows = false;
            this.dataCusname.AllowUserToDeleteRows = false;
            this.dataCusname.AllowUserToOrderColumns = true;
            this.dataCusname.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCusname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataCusname.Location = new System.Drawing.Point(3, 16);
            this.dataCusname.Name = "dataCusname";
            this.dataCusname.ReadOnly = true;
            this.dataCusname.Size = new System.Drawing.Size(978, 630);
            this.dataCusname.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.dataCusname);
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 649);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomer";
            this.Text = "Customer ID Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataCusname)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCom;
        private System.Windows.Forms.DataGridView dataCusname;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}