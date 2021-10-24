
namespace ComputerStoreProject
{
    partial class EmpForm
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
            this.btnSale = new System.Windows.Forms.Button();
            this.btnMngProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(608, 223);
            this.btnSale.Margin = new System.Windows.Forms.Padding(4);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(137, 52);
            this.btnSale.TabIndex = 2;
            this.btnSale.Text = "Sales";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnMngProduct
            // 
            this.btnMngProduct.Location = new System.Drawing.Point(320, 223);
            this.btnMngProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnMngProduct.Name = "btnMngProduct";
            this.btnMngProduct.Size = new System.Drawing.Size(172, 52);
            this.btnMngProduct.TabIndex = 3;
            this.btnMngProduct.Text = "Manage Products";
            this.btnMngProduct.UseVisualStyleBackColor = true;
            this.btnMngProduct.Click += new System.EventHandler(this.btnMngProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hello staff: ";
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.Location = new System.Drawing.Point(415, 78);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(103, 38);
            this.lbWelcome.TabIndex = 5;
            this.lbWelcome.Text = "label2";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(71, 224);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(150, 50);
            this.btnOrder.TabIndex = 6;
            this.btnOrder.Text = "Search order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(660, 409);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(123, 38);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // EmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 474);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnMngProduct);
            this.Name = "EmpForm";
            this.Text = "EmpForm";
            this.Load += new System.EventHandler(this.EmpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnMngProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnLogOut;
    }
}