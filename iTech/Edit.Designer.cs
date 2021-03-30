
namespace iTech
{
    partial class Edit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit));
            this.CloseButton = new System.Windows.Forms.Button();
            this.EditIncomeDataGridView = new System.Windows.Forms.DataGridView();
            this.EditArticle = new System.Windows.Forms.TextBox();
            this.EditQwantity = new System.Windows.Forms.TextBox();
            this.EditPrice = new System.Windows.Forms.TextBox();
            this.EditRepair = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EditIncomeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.DimGray;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseButton.Location = new System.Drawing.Point(439, 500);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(118, 36);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Затвори";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // EditIncomeDataGridView
            // 
            this.EditIncomeDataGridView.AllowUserToResizeColumns = false;
            this.EditIncomeDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.EditIncomeDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EditIncomeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EditIncomeDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EditIncomeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EditIncomeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EditIncomeDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.EditIncomeDataGridView.GridColor = System.Drawing.Color.Silver;
            this.EditIncomeDataGridView.Location = new System.Drawing.Point(31, 12);
            this.EditIncomeDataGridView.Name = "EditIncomeDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EditIncomeDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.EditIncomeDataGridView.RowTemplate.Height = 25;
            this.EditIncomeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EditIncomeDataGridView.Size = new System.Drawing.Size(933, 319);
            this.EditIncomeDataGridView.TabIndex = 1;
            this.EditIncomeDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditIncomeDataGridView_CellMouseLeave);
            this.EditIncomeDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditIncomeDataGridView_CellMouseMove);
            this.EditIncomeDataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditIncome);
            // 
            // EditArticle
            // 
            this.EditArticle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.EditArticle.Location = new System.Drawing.Point(87, 354);
            this.EditArticle.Name = "EditArticle";
            this.EditArticle.Size = new System.Drawing.Size(512, 31);
            this.EditArticle.TabIndex = 2;
            this.EditArticle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditArticle_KeyDown);
            // 
            // EditQwantity
            // 
            this.EditQwantity.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.EditQwantity.Location = new System.Drawing.Point(620, 354);
            this.EditQwantity.Name = "EditQwantity";
            this.EditQwantity.Size = new System.Drawing.Size(30, 31);
            this.EditQwantity.TabIndex = 3;
            this.EditQwantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditQwantity_KeyDown);
            this.EditQwantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditQwantity_KeyPress);
            // 
            // EditPrice
            // 
            this.EditPrice.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.EditPrice.Location = new System.Drawing.Point(670, 354);
            this.EditPrice.Name = "EditPrice";
            this.EditPrice.Size = new System.Drawing.Size(100, 31);
            this.EditPrice.TabIndex = 4;
            this.EditPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditPrice_KeyDown);
            this.EditPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditPrice_KeyPress);
            // 
            // EditRepair
            // 
            this.EditRepair.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.EditRepair.Location = new System.Drawing.Point(792, 354);
            this.EditRepair.Name = "EditRepair";
            this.EditRepair.Size = new System.Drawing.Size(100, 31);
            this.EditRepair.TabIndex = 5;
            this.EditRepair.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditRepair_KeyDown);
            this.EditRepair.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditRepair_KeyPress);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.DimGray;
            this.EditButton.Location = new System.Drawing.Point(325, 412);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(146, 45);
            this.EditButton.TabIndex = 6;
            this.EditButton.Text = "Редактиране";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            this.EditButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditButton_KeyDown);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.DimGray;
            this.DeleteButton.Location = new System.Drawing.Point(523, 412);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(136, 45);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Изтриване";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.EditRepair);
            this.Controls.Add(this.EditPrice);
            this.Controls.Add(this.EditQwantity);
            this.Controls.Add(this.EditArticle);
            this.Controls.Add(this.EditIncomeDataGridView);
            this.Controls.Add(this.CloseButton);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактиране на Приходи";
            ((System.ComponentModel.ISupportInitialize)(this.EditIncomeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.DataGridView EditIncomeDataGridView;
        private System.Windows.Forms.TextBox EditArticle;
        private System.Windows.Forms.TextBox EditQwantity;
        private System.Windows.Forms.TextBox EditPrice;
        private System.Windows.Forms.TextBox EditRepair;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}