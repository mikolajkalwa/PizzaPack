namespace gui
{
    partial class SummarizeOrderForm
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
            this.dataGridViewDishesToOrder = new System.Windows.Forms.DataGridView();
            this.buttonPlaceOrder = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.richTextBoxOrderNotes = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelToPay = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishesToOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDishesToOrder
            // 
            this.dataGridViewDishesToOrder.AllowUserToAddRows = false;
            this.dataGridViewDishesToOrder.AllowUserToOrderColumns = true;
            this.dataGridViewDishesToOrder.AllowUserToResizeColumns = false;
            this.dataGridViewDishesToOrder.AllowUserToResizeRows = false;
            this.dataGridViewDishesToOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDishesToOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDishesToOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDishesToOrder.Location = new System.Drawing.Point(12, 26);
            this.dataGridViewDishesToOrder.Name = "dataGridViewDishesToOrder";
            this.dataGridViewDishesToOrder.RowHeadersVisible = false;
            this.dataGridViewDishesToOrder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewDishesToOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDishesToOrder.ShowCellErrors = false;
            this.dataGridViewDishesToOrder.ShowEditingIcon = false;
            this.dataGridViewDishesToOrder.Size = new System.Drawing.Size(452, 234);
            this.dataGridViewDishesToOrder.TabIndex = 0;
            this.dataGridViewDishesToOrder.Text = "dataGridView1";
            this.dataGridViewDishesToOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDishesToOrder_CellClick);
            // 
            // buttonPlaceOrder
            // 
            this.buttonPlaceOrder.Location = new System.Drawing.Point(352, 499);
            this.buttonPlaceOrder.Name = "buttonPlaceOrder";
            this.buttonPlaceOrder.Size = new System.Drawing.Size(112, 24);
            this.buttonPlaceOrder.TabIndex = 1;
            this.buttonPlaceOrder.Text = "Złóż zamówienie";
            this.buttonPlaceOrder.UseVisualStyleBackColor = true;
            this.buttonPlaceOrder.Click += new System.EventHandler(this.buttonPlaceOrder_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(271, 499);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(12, 416);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(452, 23);
            this.textBoxEmail.TabIndex = 3;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 398);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(36, 15);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email";
            // 
            // richTextBoxOrderNotes
            // 
            this.richTextBoxOrderNotes.Location = new System.Drawing.Point(12, 292);
            this.richTextBoxOrderNotes.Name = "richTextBoxOrderNotes";
            this.richTextBoxOrderNotes.Size = new System.Drawing.Size(452, 87);
            this.richTextBoxOrderNotes.TabIndex = 5;
            this.richTextBoxOrderNotes.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Uwagi do zamówienia";
            // 
            // labelToPay
            // 
            this.labelToPay.AutoSize = true;
            this.labelToPay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelToPay.Location = new System.Drawing.Point(351, 461);
            this.labelToPay.Name = "labelToPay";
            this.labelToPay.Size = new System.Drawing.Size(69, 15);
            this.labelToPay.TabIndex = 7;
            this.labelToPay.Text = "Do zapłaty:";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTotalPrice.Location = new System.Drawing.Point(426, 461);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(44, 15);
            this.labelTotalPrice.TabIndex = 8;
            this.labelTotalPrice.Text = "0,00 zł";
            // 
            // SummarizeOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 540);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.labelToPay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxOrderNotes);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPlaceOrder);
            this.Controls.Add(this.dataGridViewDishesToOrder);
            this.Name = "SummarizeOrderForm";
            this.Text = "Podsumowanie zamówienia";
            this.Load += new System.EventHandler(this.SummarizeOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishesToOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDishesToOrder;
        private System.Windows.Forms.Button buttonPlaceOrder;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.RichTextBox richTextBoxOrderNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelToPay;
        private System.Windows.Forms.Label labelTotalPrice;
    }
}