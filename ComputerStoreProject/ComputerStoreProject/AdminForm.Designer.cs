
namespace ComputerStoreProject
{
    partial class AdminForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMngUser = new System.Windows.Forms.Button();
            this.btnMngProduct = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to System Management";
            // 
            // btnMngUser
            // 
            this.btnMngUser.Location = new System.Drawing.Point(71, 228);
            this.btnMngUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMngUser.Name = "btnMngUser";
            this.btnMngUser.Size = new System.Drawing.Size(187, 52);
            this.btnMngUser.TabIndex = 1;
            this.btnMngUser.Text = "Mange Store\'s User";
            this.btnMngUser.UseVisualStyleBackColor = true;
            this.btnMngUser.Click += new System.EventHandler(this.btnMngUser_Click);
            // 
            // btnMngProduct
            // 
            this.btnMngProduct.Location = new System.Drawing.Point(380, 228);
            this.btnMngProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMngProduct.Name = "btnMngProduct";
            this.btnMngProduct.Size = new System.Drawing.Size(172, 52);
            this.btnMngProduct.TabIndex = 1;
            this.btnMngProduct.Text = "Manage Products";
            this.btnMngProduct.UseVisualStyleBackColor = true;
            this.btnMngProduct.Click += new System.EventHandler(this.btnMngProduct_Click);
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(688, 228);
            this.btnSale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(137, 52);
            this.btnSale.TabIndex = 1;
            this.btnSale.Text = "Sales";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWelcome.Location = new System.Drawing.Point(623, 95);
            this.lbWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(0, 25);
            this.lbWelcome.TabIndex = 2;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(728, 471);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(166, 48);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 554);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnMngProduct);
            this.Controls.Add(this.btnMngUser);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMngUser;
        private System.Windows.Forms.Button btnMngProduct;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button btnLogOut;
    }
}