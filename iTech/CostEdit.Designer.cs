
namespace iTech
{
    partial class CostEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostEdit));
            this.button1 = new System.Windows.Forms.Button();
            this.EditCostDataGridView = new System.Windows.Forms.DataGridView();
            this.EditNameCostBox = new System.Windows.Forms.TextBox();
            this.EditSumCostBox = new System.Windows.Forms.TextBox();
            this.EditCostButton = new System.Windows.Forms.Button();
            this.DeleteCostButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EditCostDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(439, 500);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Затвори";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditCostDataGridView
            // 
            this.EditCostDataGridView.AllowUserToResizeColumns = false;
            this.EditCostDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.EditCostDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EditCostDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EditCostDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EditCostDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EditCostDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EditCostDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.EditCostDataGridView.GridColor = System.Drawing.Color.Silver;
            this.EditCostDataGridView.Location = new System.Drawing.Point(31, 12);
            this.EditCostDataGridView.Name = "EditCostDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EditCostDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.EditCostDataGridView.RowHeadersVisible = false;
            this.EditCostDataGridView.RowHeadersWidth = 51;
            this.EditCostDataGridView.RowTemplate.Height = 25;
            this.EditCostDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EditCostDataGridView.Size = new System.Drawing.Size(933, 319);
            this.EditCostDataGridView.TabIndex = 1;
            this.EditCostDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditCostDataGridView_CellMouseLeave);
            this.EditCostDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditCostDataGridView_CellMouseMove);
            this.EditCostDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditCost);
            this.EditCostDataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditCost);
            // 
            // EditNameCostBox
            // 
            this.EditNameCostBox.Location = new System.Drawing.Point(143, 354);
            this.EditNameCostBox.Name = "EditNameCostBox";
            this.EditNameCostBox.Size = new System.Drawing.Size(430, 36);
            this.EditNameCostBox.TabIndex = 2;
            this.EditNameCostBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditNameCostBox_KeyDown);
            // 
            // EditSumCostBox
            // 
            this.EditSumCostBox.Location = new System.Drawing.Point(624, 354);
            this.EditSumCostBox.Name = "EditSumCostBox";
            this.EditSumCostBox.Size = new System.Drawing.Size(107, 36);
            this.EditSumCostBox.TabIndex = 3;
            this.EditSumCostBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditSumCostBox_KeyDown);
            this.EditSumCostBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditSumCostBox_KeyPress);
            // 
            // EditCostButton
            // 
            this.EditCostButton.BackColor = System.Drawing.Color.DimGray;
            this.EditCostButton.Location = new System.Drawing.Point(325, 412);
            this.EditCostButton.Name = "EditCostButton";
            this.EditCostButton.Size = new System.Drawing.Size(146, 45);
            this.EditCostButton.TabIndex = 4;
            this.EditCostButton.Text = "Редактиране";
            this.EditCostButton.UseVisualStyleBackColor = false;
            this.EditCostButton.Click += new System.EventHandler(this.EditCostButton_Click);
            this.EditCostButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditCostButton_KeyDown);
            // 
            // DeleteCostButton
            // 
            this.DeleteCostButton.BackColor = System.Drawing.Color.DimGray;
            this.DeleteCostButton.Location = new System.Drawing.Point(523, 412);
            this.DeleteCostButton.Name = "DeleteCostButton";
            this.DeleteCostButton.Size = new System.Drawing.Size(136, 45);
            this.DeleteCostButton.TabIndex = 5;
            this.DeleteCostButton.Text = "Изтриване";
            this.DeleteCostButton.UseVisualStyleBackColor = false;
            this.DeleteCostButton.Click += new System.EventHandler(this.DeleteCostButton_Click);
            // 
            // CostEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.DeleteCostButton);
            this.Controls.Add(this.EditCostButton);
            this.Controls.Add(this.EditSumCostBox);
            this.Controls.Add(this.EditNameCostBox);
            this.Controls.Add(this.EditCostDataGridView);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CostEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактиране на Разходи";
            ((System.ComponentModel.ISupportInitialize)(this.EditCostDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView EditCostDataGridView;
        private System.Windows.Forms.TextBox EditNameCostBox;
        private System.Windows.Forms.TextBox EditSumCostBox;
        private System.Windows.Forms.Button EditCostButton;
        private System.Windows.Forms.Button DeleteCostButton;
    }
}