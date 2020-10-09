namespace gui
{
    partial class MainForm
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
            this.buttonAddDishToOrder = new System.Windows.Forms.Button();
            this.buttonPlaceOrder = new System.Windows.Forms.Button();
            this.labelTotalPriceInfo = new System.Windows.Forms.Label();
            this.labelCurrentValue = new System.Windows.Forms.Label();
            this.dataGridViewMenu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddDishToOrder
            // 
            this.buttonAddDishToOrder.Location = new System.Drawing.Point(599, 331);
            this.buttonAddDishToOrder.Name = "buttonAddDishToOrder";
            this.buttonAddDishToOrder.Size = new System.Drawing.Size(189, 23);
            this.buttonAddDishToOrder.TabIndex = 0;
            this.buttonAddDishToOrder.Text = "Dodaj do zamówienia";
            this.buttonAddDishToOrder.UseVisualStyleBackColor = true;
            // 
            // buttonPlaceOrder
            // 
            this.buttonPlaceOrder.Location = new System.Drawing.Point(512, 415);
            this.buttonPlaceOrder.Name = "buttonPlaceOrder";
            this.buttonPlaceOrder.Size = new System.Drawing.Size(276, 23);
            this.buttonPlaceOrder.TabIndex = 1;
            this.buttonPlaceOrder.Text = "Złóż zamówienie";
            this.buttonPlaceOrder.UseVisualStyleBackColor = true;
            // 
            // labelTotalPriceInfo
            // 
            this.labelTotalPriceInfo.AutoSize = true;
            this.labelTotalPriceInfo.Location = new System.Drawing.Point(593, 378);
            this.labelTotalPriceInfo.Name = "labelTotalPriceInfo";
            this.labelTotalPriceInfo.Size = new System.Drawing.Size(38, 15);
            this.labelTotalPriceInfo.TabIndex = 2;
            this.labelTotalPriceInfo.Text = "Koszt:";
            this.labelTotalPriceInfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelCurrentValue
            // 
            this.labelCurrentValue.AutoSize = true;
            this.labelCurrentValue.Location = new System.Drawing.Point(649, 378);
            this.labelCurrentValue.Name = "labelCurrentValue";
            this.labelCurrentValue.Size = new System.Drawing.Size(24, 15);
            this.labelCurrentValue.TabIndex = 3;
            this.labelCurrentValue.Text = "0 zł";
            // 
            // dataGridViewMenu
            // 
            this.dataGridViewMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenu.Location = new System.Drawing.Point(12, 23);
            this.dataGridViewMenu.Name = "dataGridViewMenu";
            this.dataGridViewMenu.Size = new System.Drawing.Size(776, 302);
            this.dataGridViewMenu.TabIndex = 4;
            this.dataGridViewMenu.Text = "dataGridView1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewMenu);
            this.Controls.Add(this.labelCurrentValue);
            this.Controls.Add(this.labelTotalPriceInfo);
            this.Controls.Add(this.buttonPlaceOrder);
            this.Controls.Add(this.buttonAddDishToOrder);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddDishToOrder;
        private System.Windows.Forms.Button buttonPlaceOrder;
        private System.Windows.Forms.Label labelTotalPriceInfo;
        private System.Windows.Forms.Label labelCurrentValue;
        private System.Windows.Forms.DataGridView dataGridViewMenu;
    }
}