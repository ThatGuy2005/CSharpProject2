namespace Lab4CSharp
{
    partial class CategoriesForm
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
            this.components = new System.ComponentModel.Container();
            this.categoriesGrid = new System.Windows.Forms.DataGridView();
            this.categoryName = new System.Windows.Forms.TextBox();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denumireDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categorieProdusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.rename = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieProdusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // categoriesGrid
            // 
            this.categoriesGrid.AutoGenerateColumns = false;
            this.categoriesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.denumireDataGridViewTextBoxColumn});
            this.categoriesGrid.DataSource = this.categorieProdusBindingSource;
            this.categoriesGrid.Location = new System.Drawing.Point(230, 120);
            this.categoriesGrid.Name = "categoriesGrid";
            this.categoriesGrid.RowHeadersWidth = 62;
            this.categoriesGrid.RowTemplate.Height = 28;
            this.categoriesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoriesGrid.Size = new System.Drawing.Size(370, 148);
            this.categoriesGrid.TabIndex = 0;
            // 
            // categoryName
            // 
            this.categoryName.Location = new System.Drawing.Point(331, 305);
            this.categoryName.Name = "categoryName";
            this.categoryName.Size = new System.Drawing.Size(206, 26);
            this.categoryName.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // denumireDataGridViewTextBoxColumn
            // 
            this.denumireDataGridViewTextBoxColumn.DataPropertyName = "Denumire";
            this.denumireDataGridViewTextBoxColumn.HeaderText = "Denumire";
            this.denumireDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.denumireDataGridViewTextBoxColumn.Name = "denumireDataGridViewTextBoxColumn";
            this.denumireDataGridViewTextBoxColumn.Width = 150;
            // 
            // categorieProdusBindingSource
            // 
            this.categorieProdusBindingSource.DataSource = typeof(Lab4CSharp.CategorieProdus);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(660, 274);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 27);
            this.add.TabIndex = 2;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(660, 367);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 28);
            this.delete.TabIndex = 3;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click_1);
            // 
            // rename
            // 
            this.rename.Location = new System.Drawing.Point(660, 318);
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(75, 32);
            this.rename.TabIndex = 4;
            this.rename.Text = "Rename";
            this.rename.UseVisualStyleBackColor = true;
            this.rename.Click += new System.EventHandler(this.rename_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter category name:";
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rename);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.categoryName);
            this.Controls.Add(this.categoriesGrid);
            this.Name = "CategoriesForm";
            this.Text = "CategoriesForm";
            this.Load += new System.EventHandler(this.CategoriesForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorieProdusBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView categoriesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn denumireDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource categorieProdusBindingSource;
        private System.Windows.Forms.TextBox categoryName;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button rename;
        private System.Windows.Forms.Label label1;
    }
}