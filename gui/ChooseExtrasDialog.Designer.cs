namespace gui
{
    partial class ChooseExtrasDialog
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
            this.checkedListBoxAvailableExtras = new System.Windows.Forms.CheckedListBox();
            this.buttonConfirmExtras = new System.Windows.Forms.Button();
            this.buttonCancelExtrasOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxAvailableExtras
            // 
            this.checkedListBoxAvailableExtras.FormattingEnabled = true;
            this.checkedListBoxAvailableExtras.Location = new System.Drawing.Point(27, 23);
            this.checkedListBoxAvailableExtras.Name = "checkedListBoxAvailableExtras";
            this.checkedListBoxAvailableExtras.Size = new System.Drawing.Size(263, 202);
            this.checkedListBoxAvailableExtras.TabIndex = 0;
            // 
            // buttonConfirmExtras
            // 
            this.buttonConfirmExtras.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirmExtras.Location = new System.Drawing.Point(215, 255);
            this.buttonConfirmExtras.Name = "buttonConfirmExtras";
            this.buttonConfirmExtras.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmExtras.TabIndex = 2;
            this.buttonConfirmExtras.Text = "Zatwierdź";
            this.buttonConfirmExtras.UseVisualStyleBackColor = true;
            this.buttonConfirmExtras.Click += new System.EventHandler(this.buttonConfirmExtras_Click);
            // 
            // buttonCancelExtrasOrder
            // 
            this.buttonCancelExtrasOrder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelExtrasOrder.Location = new System.Drawing.Point(134, 255);
            this.buttonCancelExtrasOrder.Name = "buttonCancelExtrasOrder";
            this.buttonCancelExtrasOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelExtrasOrder.TabIndex = 1;
            this.buttonCancelExtrasOrder.Text = "Anuluj";
            this.buttonCancelExtrasOrder.UseVisualStyleBackColor = true;
            this.buttonCancelExtrasOrder.Click += new System.EventHandler(this.buttonCancelExtrasOrder_Click);
            // 
            // ChooseExtrasDialog
            // 
            this.AcceptButton = this.buttonConfirmExtras;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelExtrasOrder;
            this.ClientSize = new System.Drawing.Size(327, 328);
            this.Controls.Add(this.buttonCancelExtrasOrder);
            this.Controls.Add(this.buttonConfirmExtras);
            this.Controls.Add(this.checkedListBoxAvailableExtras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChooseExtrasDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybór dodatków";
            this.Load += new System.EventHandler(this.ChooseExtras_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxAvailableExtras;
        private System.Windows.Forms.Button buttonConfirmExtras;
        private System.Windows.Forms.Button buttonCancelExtrasOrder;
    }
}