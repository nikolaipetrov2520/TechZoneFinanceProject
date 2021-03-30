using DataBase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTech
{
    public partial class CostEdit : Form
    {
        private List<Cost> dateCostList;
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly TechZoneContext techzone;
        private int editId = 0;

        public CostEdit(DateTime startDate, DateTime endDate, TechZoneContext techzone)
        {
            InitializeComponent();
            dateCostList = new List<Cost>();
            this.startDate = startDate;
            this.endDate = endDate;
            this.techzone = techzone;
            makeReference();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void makeReference()
        {

            dateCostList.Clear();

            dateCostList = techzone.Costs
                .Where(x => x.Date >= startDate && x.Date <= endDate)
                .Select(x => new Cost
                {
                    Id = x.Id,
                    Date = x.Date,
                    Sum = x.Sum,
                    Name = x.Name,
                })
                .ToList();
            EditCostDataGridView.DataSource = null;
            EditCostDataGridView.DataSource = dateCostList;
            EditCostDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            EditCostDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            EditCostDataGridView.EnableHeadersVisualStyles = false;
            EditCostDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            EditCostDataGridView.Columns[0].Width = 60;
            EditCostDataGridView.Columns[0].HeaderText = "ID";
            EditCostDataGridView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditCostDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            EditCostDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            EditCostDataGridView.Columns[1].Width = 118;
            EditCostDataGridView.Columns[1].HeaderText = "Дата";
            EditCostDataGridView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditCostDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            EditCostDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            EditCostDataGridView.Columns[2].Width = 600;
            EditCostDataGridView.Columns[2].HeaderText = "Разход";
            EditCostDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditCostDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            EditCostDataGridView.Columns[3].HeaderText = "Сума";
            EditCostDataGridView.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditCostDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void EditCost(object sender, DataGridViewCellMouseEventArgs e)
        {
            editId = int.Parse(EditCostDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            EditNameCostBox.Text = EditCostDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            EditSumCostBox.Text = EditCostDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
           
        }

        private void EditCostButton_Click(object sender, EventArgs e)
        {
            if (editId > 0)
            {
                if (EditNameCostBox.Text != "")
                {
                    string sumString = "0";                 

                    if (EditSumCostBox.Text != "")
                    {
                        if (EditSumCostBox.Text != "." && EditSumCostBox.Text != ",")
                        {
                            sumString = EditSumCostBox.Text.ToString();
                        }

                    }

                    for (int i = 0; i < sumString.Length; i++)
                    {
                        if (sumString[i] == ',')
                        {
                            string priStr1 = sumString.Substring(0, i);
                            string priStr2 = sumString.Substring(i + 1);
                            sumString = priStr1 + '.' + priStr2;
                        }
                    }

                    var entity = techzone.Costs.FirstOrDefault(X => X.Id == editId);
                    entity.Name = EditNameCostBox.Text;                
                    entity.Sum = decimal.Parse(sumString);

                    if (DialogResult.Yes == MessageBox.Show("Сигурни ли сте че искате да редактирате този запис ?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {

                        techzone.SaveChanges();
                        makeReference();

                        EditNameCostBox.Text = "";
                        EditSumCostBox.Text = "";
                        editId = 0;

                        MessageBox.Show("Редактирахте успешно Записа");
                    }
                }

                else
                {
                    EditNameCostBox.Select();
                }
            }
            else
            {
                MessageBox.Show("Моля изберете ред");
            }
        }

        private void DeleteCostButton_Click(object sender, EventArgs e)
        {
            if (editId > 0)
            {
                var entity = techzone.Costs.FirstOrDefault(X => X.Id == editId);
                techzone.Costs.Remove(entity);

                if (DialogResult.Yes == MessageBox.Show("Сигурни ли сте че искате да Изтриете този запис ?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    techzone.SaveChanges();
                    makeReference();

                    EditNameCostBox.Text = "";
                    EditSumCostBox.Text = "";
                    editId = 0;

                    MessageBox.Show("Изтрихте успешно Записа");
                }
            }
            else
            {
                MessageBox.Show("Моля изберете ред");
            }
        }

        private void EditNameCostBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EditSumCostBox.Select();
            }
        }

        private void EditSumCostBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EditCostButton.Select();
            }
        }

        private void EditCostButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EditCostButton_Click(sender, e);
            }
        }

        private void EditSumCostBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void EditCostDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                EditCostDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;

            }
        }

        private void EditCostDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                EditCostDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

            }
        }
    }
}
