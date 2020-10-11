namespace gui
{
    partial class OrdersHistoryForm
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
            this.listBoxOrders = new System.Windows.Forms.ListBox();
            this.groupBoxOrders = new System.Windows.Forms.GroupBox();
            this.groupBoxOrderDetails = new System.Windows.Forms.GroupBox();
            this.labelOrderIdentifier = new System.Windows.Forms.Label();
            this.textBoxOrderidentifier = new System.Windows.Forms.TextBox();
            this.textBoxOrderDate = new System.Windows.Forms.TextBox();
            this.labelOrderDate = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelOrderPrice = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.dataGridViewOrderedDishes = new System.Windows.Forms.DataGridView();
            this.labelOrderedDishes = new System.Windows.Forms.Label();
            this.labelNotes = new System.Windows.Forms.Label();
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.groupBoxOrders.SuspendLayout();
            this.groupBoxOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderedDishes)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxOrders
            // 
            this.listBoxOrders.FormattingEnabled = true;
            this.listBoxOrders.ItemHeight = 15;
            this.listBoxOrders.Location = new System.Drawing.Point(6, 22);
            this.listBoxOrders.Name = "listBoxOrders";
            this.listBoxOrders.Size = new System.Drawing.Size(310, 574);
            this.listBoxOrders.TabIndex = 0;
            this.listBoxOrders.SelectedIndexChanged += new System.EventHandler(this.listBoxOrders_SelectedIndexChanged);
            // 
            // groupBoxOrders
            // 
            this.groupBoxOrders.Controls.Add(this.listBoxOrders);
            this.groupBoxOrders.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOrders.Name = "groupBoxOrders";
            this.groupBoxOrders.Size = new System.Drawing.Size(322, 600);
            this.groupBoxOrders.TabIndex = 1;
            this.groupBoxOrders.TabStop = false;
            this.groupBoxOrders.Text = "Zamówienia";
            // 
            // groupBoxOrderDetails
            // 
            this.groupBoxOrderDetails.Controls.Add(this.labelOrderIdentifier);
            this.groupBoxOrderDetails.Controls.Add(this.textBoxOrderidentifier);
            this.groupBoxOrderDetails.Controls.Add(this.textBoxOrderDate);
            this.groupBoxOrderDetails.Controls.Add(this.labelOrderDate);
            this.groupBoxOrderDetails.Controls.Add(this.textBoxEmail);
            this.groupBoxOrderDetails.Controls.Add(this.labelEmail);
            this.groupBoxOrderDetails.Controls.Add(this.labelOrderPrice);
            this.groupBoxOrderDetails.Controls.Add(this.textBoxTotalPrice);
            this.groupBoxOrderDetails.Controls.Add(this.dataGridViewOrderedDishes);
            this.groupBoxOrderDetails.Controls.Add(this.labelOrderedDishes);
            this.groupBoxOrderDetails.Controls.Add(this.labelNotes);
            this.groupBoxOrderDetails.Controls.Add(this.richTextBoxNotes);
            this.groupBoxOrderDetails.Location = new System.Drawing.Point(340, 12);
            this.groupBoxOrderDetails.Name = "groupBoxOrderDetails";
            this.groupBoxOrderDetails.Size = new System.Drawing.Size(550, 600);
            this.groupBoxOrderDetails.TabIndex = 2;
            this.groupBoxOrderDetails.TabStop = false;
            this.groupBoxOrderDetails.Text = "Szczegóły zamówienia";
            // 
            // labelOrderIdentifier
            // 
            this.labelOrderIdentifier.AutoSize = true;
            this.labelOrderIdentifier.Location = new System.Drawing.Point(6, 550);
            this.labelOrderIdentifier.Name = "labelOrderIdentifier";
            this.labelOrderIdentifier.Size = new System.Drawing.Size(140, 15);
            this.labelOrderIdentifier.TabIndex = 11;
            this.labelOrderIdentifier.Text = "Identyfikator zamówienia";
            // 
            // textBoxOrderidentifier
            // 
            this.textBoxOrderidentifier.Enabled = false;
            this.textBoxOrderidentifier.Location = new System.Drawing.Point(6, 568);
            this.textBoxOrderidentifier.Name = "textBoxOrderidentifier";
            this.textBoxOrderidentifier.ReadOnly = true;
            this.textBoxOrderidentifier.Size = new System.Drawing.Size(538, 23);
            this.textBoxOrderidentifier.TabIndex = 10;
            // 
            // textBoxOrderDate
            // 
            this.textBoxOrderDate.Enabled = false;
            this.textBoxOrderDate.Location = new System.Drawing.Point(8, 524);
            this.textBoxOrderDate.Name = "textBoxOrderDate";
            this.textBoxOrderDate.ReadOnly = true;
            this.textBoxOrderDate.Size = new System.Drawing.Size(536, 23);
            this.textBoxOrderDate.TabIndex = 9;
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new System.Drawing.Point(8, 505);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(142, 15);
            this.labelOrderDate.TabIndex = 8;
            this.labelOrderDate.Text = "Data złożenia zamówienia";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Enabled = false;
            this.textBoxEmail.Location = new System.Drawing.Point(7, 479);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.ReadOnly = true;
            this.textBoxEmail.Size = new System.Drawing.Size(537, 23);
            this.textBoxEmail.TabIndex = 7;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(8, 460);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(36, 15);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Email";
            // 
            // labelOrderPrice
            // 
            this.labelOrderPrice.AutoSize = true;
            this.labelOrderPrice.Location = new System.Drawing.Point(6, 416);
            this.labelOrderPrice.Name = "labelOrderPrice";
            this.labelOrderPrice.Size = new System.Drawing.Size(116, 15);
            this.labelOrderPrice.TabIndex = 5;
            this.labelOrderPrice.Text = "Wartość zamówienia";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Enabled = false;
            this.textBoxTotalPrice.Location = new System.Drawing.Point(8, 434);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(536, 23);
            this.textBoxTotalPrice.TabIndex = 4;
            // 
            // dataGridViewOrderedDishes
            // 
            this.dataGridViewOrderedDishes.AllowUserToAddRows = false;
            this.dataGridViewOrderedDishes.AllowUserToDeleteRows = false;
            this.dataGridViewOrderedDishes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrderedDishes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrderedDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderedDishes.Location = new System.Drawing.Point(6, 153);
            this.dataGridViewOrderedDishes.Name = "dataGridViewOrderedDishes";
            this.dataGridViewOrderedDishes.RowHeadersVisible = false;
            this.dataGridViewOrderedDishes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewOrderedDishes.Size = new System.Drawing.Size(538, 260);
            this.dataGridViewOrderedDishes.TabIndex = 3;
            this.dataGridViewOrderedDishes.Text = "dataGridView1";
            // 
            // labelOrderedDishes
            // 
            this.labelOrderedDishes.AutoSize = true;
            this.labelOrderedDishes.Location = new System.Drawing.Point(6, 135);
            this.labelOrderedDishes.Name = "labelOrderedDishes";
            this.labelOrderedDishes.Size = new System.Drawing.Size(102, 15);
            this.labelOrderedDishes.TabIndex = 2;
            this.labelOrderedDishes.Text = "Zamówione dania";
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(6, 22);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(123, 15);
            this.labelNotes.TabIndex = 1;
            this.labelNotes.Text = "Uwagi do zamówienia";
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Enabled = false;
            this.richTextBoxNotes.Location = new System.Drawing.Point(6, 40);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.ReadOnly = true;
            this.richTextBoxNotes.Size = new System.Drawing.Size(538, 92);
            this.richTextBoxNotes.TabIndex = 0;
            this.richTextBoxNotes.Text = "";
            // 
            // OrdersHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 624);
            this.Controls.Add(this.groupBoxOrderDetails);
            this.Controls.Add(this.groupBoxOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OrdersHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historia zamówień";
            this.Load += new System.EventHandler(this.OrdersHistoryForm_Load);
            this.groupBoxOrders.ResumeLayout(false);
            this.groupBoxOrderDetails.ResumeLayout(false);
            this.groupBoxOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderedDishes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxOrders;
        private System.Windows.Forms.GroupBox groupBoxOrders;
        private System.Windows.Forms.GroupBox groupBoxOrderDetails;
        private System.Windows.Forms.Label labelOrderIdentifier;
        private System.Windows.Forms.TextBox textBoxOrderidentifier;
        private System.Windows.Forms.TextBox textBoxOrderDate;
        private System.Windows.Forms.Label labelOrderDate;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelOrderPrice;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.DataGridView dataGridViewOrderedDishes;
        private System.Windows.Forms.Label labelOrderedDishes;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
    }
}