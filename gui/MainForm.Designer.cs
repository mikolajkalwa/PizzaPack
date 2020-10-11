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
            this.buttonSummarizeOrder = new System.Windows.Forms.Button();
            this.labelTotalPriceInfo = new System.Windows.Forms.Label();
            this.labelCurrentValue = new System.Windows.Forms.Label();
            this.dataGridViewMenu = new System.Windows.Forms.DataGridView();
            this.numericUpDownDishQuantity = new System.Windows.Forms.NumericUpDown();
            this.buttonOrdersHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDishQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddDishToOrder
            // 
            this.buttonAddDishToOrder.Location = new System.Drawing.Point(599, 331);
            this.buttonAddDishToOrder.Name = "buttonAddDishToOrder";
            this.buttonAddDishToOrder.Size = new System.Drawing.Size(189, 25);
            this.buttonAddDishToOrder.TabIndex = 2;
            this.buttonAddDishToOrder.Text = "Dodaj do zamówienia";
            this.buttonAddDishToOrder.UseVisualStyleBackColor = true;
            this.buttonAddDishToOrder.Click += new System.EventHandler(this.buttonAddDishToOrder_Click);
            // 
            // buttonSummarizeOrder
            // 
            this.buttonSummarizeOrder.Location = new System.Drawing.Point(512, 415);
            this.buttonSummarizeOrder.Name = "buttonSummarizeOrder";
            this.buttonSummarizeOrder.Size = new System.Drawing.Size(276, 23);
            this.buttonSummarizeOrder.TabIndex = 5;
            this.buttonSummarizeOrder.Text = "Podsumowanie zamówienia";
            this.buttonSummarizeOrder.UseVisualStyleBackColor = true;
            this.buttonSummarizeOrder.Click += new System.EventHandler(this.buttonSummarizeOrder_Click);
            // 
            // labelTotalPriceInfo
            // 
            this.labelTotalPriceInfo.AutoSize = true;
            this.labelTotalPriceInfo.Location = new System.Drawing.Point(705, 378);
            this.labelTotalPriceInfo.Name = "labelTotalPriceInfo";
            this.labelTotalPriceInfo.Size = new System.Drawing.Size(38, 15);
            this.labelTotalPriceInfo.TabIndex = 3;
            this.labelTotalPriceInfo.Text = "Koszt:";
            // 
            // labelCurrentValue
            // 
            this.labelCurrentValue.AutoSize = true;
            this.labelCurrentValue.Location = new System.Drawing.Point(749, 378);
            this.labelCurrentValue.Name = "labelCurrentValue";
            this.labelCurrentValue.Size = new System.Drawing.Size(39, 15);
            this.labelCurrentValue.TabIndex = 4;
            this.labelCurrentValue.Text = "0,00 zł";
            // 
            // dataGridViewMenu
            // 
            this.dataGridViewMenu.AllowUserToAddRows = false;
            this.dataGridViewMenu.AllowUserToDeleteRows = false;
            this.dataGridViewMenu.AllowUserToResizeColumns = false;
            this.dataGridViewMenu.AllowUserToResizeRows = false;
            this.dataGridViewMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMenu.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenu.Location = new System.Drawing.Point(12, 23);
            this.dataGridViewMenu.MultiSelect = false;
            this.dataGridViewMenu.Name = "dataGridViewMenu";
            this.dataGridViewMenu.RowHeadersVisible = false;
            this.dataGridViewMenu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMenu.ShowCellErrors = false;
            this.dataGridViewMenu.ShowCellToolTips = false;
            this.dataGridViewMenu.ShowEditingIcon = false;
            this.dataGridViewMenu.ShowRowErrors = false;
            this.dataGridViewMenu.Size = new System.Drawing.Size(776, 302);
            this.dataGridViewMenu.TabIndex = 0;
            this.dataGridViewMenu.Text = "dataGridView1";
            // 
            // numericUpDownDishQuantity
            // 
            this.numericUpDownDishQuantity.Location = new System.Drawing.Point(473, 333);
            this.numericUpDownDishQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDishQuantity.Name = "numericUpDownDishQuantity";
            this.numericUpDownDishQuantity.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownDishQuantity.TabIndex = 1;
            this.numericUpDownDishQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonOrdersHistory
            // 
            this.buttonOrdersHistory.Location = new System.Drawing.Point(13, 415);
            this.buttonOrdersHistory.Name = "buttonOrdersHistory";
            this.buttonOrdersHistory.Size = new System.Drawing.Size(133, 23);
            this.buttonOrdersHistory.TabIndex = 6;
            this.buttonOrdersHistory.Text = "Historia zamówień";
            this.buttonOrdersHistory.UseVisualStyleBackColor = true;
            this.buttonOrdersHistory.Click += new System.EventHandler(this.buttonOrdersHistory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonOrdersHistory);
            this.Controls.Add(this.numericUpDownDishQuantity);
            this.Controls.Add(this.dataGridViewMenu);
            this.Controls.Add(this.labelCurrentValue);
            this.Controls.Add(this.labelTotalPriceInfo);
            this.Controls.Add(this.buttonSummarizeOrder);
            this.Controls.Add(this.buttonAddDishToOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PizzaPack";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDishQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddDishToOrder;
        private System.Windows.Forms.Button buttonSummarizeOrder;
        private System.Windows.Forms.Label labelTotalPriceInfo;
        private System.Windows.Forms.Label labelCurrentValue;
        private System.Windows.Forms.DataGridView dataGridViewMenu;
        private System.Windows.Forms.NumericUpDown numericUpDownDishQuantity;
        private System.Windows.Forms.Button buttonOrdersHistory;
    }
}