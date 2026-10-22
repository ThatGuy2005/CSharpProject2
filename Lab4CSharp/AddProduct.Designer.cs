namespace Lab4CSharp
{
    partial class AddProduct
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
            this.productName = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.TextBox();
            this.productDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.arrivalDate = new System.Windows.Forms.DateTimePicker();
            this.expirationDate = new System.Windows.Forms.DateTimePicker();
            this.add = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productName
            // 
            this.productName.Location = new System.Drawing.Point(294, 44);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(219, 26);
            this.productName.TabIndex = 0;
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(294, 384);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(219, 26);
            this.quantity.TabIndex = 3;
            // 
            // productDescription
            // 
            this.productDescription.Location = new System.Drawing.Point(294, 96);
            this.productDescription.Name = "productDescription";
            this.productDescription.Size = new System.Drawing.Size(219, 136);
            this.productDescription.TabIndex = 4;
            this.productDescription.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Product Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Arrival:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Expiration Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity:";
            // 
            // arrivalDate
            // 
            this.arrivalDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.arrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.arrivalDate.Location = new System.Drawing.Point(294, 261);
            this.arrivalDate.Name = "arrivalDate";
            this.arrivalDate.Size = new System.Drawing.Size(219, 26);
            this.arrivalDate.TabIndex = 10;
            // 
            // expirationDate
            // 
            this.expirationDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.expirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expirationDate.Location = new System.Drawing.Point(294, 320);
            this.expirationDate.Name = "expirationDate";
            this.expirationDate.Size = new System.Drawing.Size(219, 26);
            this.expirationDate.TabIndex = 11;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(657, 320);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(110, 38);
            this.add.TabIndex = 12;
            this.add.Text = "Add Product";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(657, 384);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(110, 42);
            this.quit.TabIndex = 13;
            this.quit.Text = "Quit";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.expirationDate);
            this.Controls.Add(this.arrivalDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productDescription);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.productName);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox productName;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.RichTextBox productDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker arrivalDate;
        private System.Windows.Forms.DateTimePicker expirationDate;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button quit;
    }
}