
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
            this.button3 = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to System Management";
            // 
            // btnMngUser
            // 
            this.btnMngUser.Location = new System.Drawing.Point(53, 185);
            this.btnMngUser.Name = "btnMngUser";
            this.btnMngUser.Size = new System.Drawing.Size(140, 42);
            this.btnMngUser.TabIndex = 1;
            this.btnMngUser.Text = "Mange Store\'s User";
            this.btnMngUser.UseVisualStyleBackColor = true;
            this.btnMngUser.Click += new System.EventHandler(this.btnMngUser_Click);
            // 
            // btnMngProduct
            // 
            this.btnMngProduct.Location = new System.Drawing.Point(285, 185);
            this.btnMngProduct.Name = "btnMngProduct";
            this.btnMngProduct.Size = new System.Drawing.Size(129, 42);
            this.btnMngProduct.TabIndex = 1;
            this.btnMngProduct.Text = "Manage Products";
            this.btnMngProduct.UseVisualStyleBackColor = true;
            this.btnMngProduct.Click += new System.EventHandler(this.btnMngProduct_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(516, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 42);
            this.button3.TabIndex = 1;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbWelcome.Location = new System.Drawing.Point(467, 77);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(0, 20);
            this.lbWelcome.TabIndex = 2;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnMngProduct);
            this.Controls.Add(this.btnMngUser);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbWelcome;
    }
}