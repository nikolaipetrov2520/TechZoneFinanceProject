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
    public partial class Edit : Form
    {

        private List<Income> dateIncomeList;
        private readonly TechZoneContext techzone;
        private int editId = 0;

        private DateTime startDate { get; }
        private DateTime endDate { get; }

        public Edit(DateTime startDate, DateTime endDate, TechZoneContext techzone)
        {
            InitializeComponent();
            dateIncomeList = new List<Income>();
            this.startDate = startDate;
            this.endDate = endDate;
            this.techzone = techzone;
            makeReference();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void makeReference()
        {

            dateIncomeList.Clear();

            dateIncomeList = techzone.Incomes
                .Where(x => x.Date >= startDate && x.Date <= endDate)
                .Select(x => new Income
                {
                    Id = x.Id,
                    Date = x.Date,
                    UserId = x.UserId,
                    Article = x.Article,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Repair = x.Repair
                })
                .ToList();

            EditIncomeDataGridView.DataSource = null;
            EditIncomeDataGridView.DataSource = dateIncomeList;
            EditIncomeDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            EditIncomeDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            EditIncomeDataGridView.EnableHeadersVisualStyles = false;

            EditIncomeDataGridView.Columns[0].HeaderText = "ID";
            EditIncomeDataGridView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            EditIncomeDataGridView.Columns[1].HeaderText = "Дата";
            EditIncomeDataGridView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            EditIncomeDataGridView.Columns[2].HeaderText = "User";
            EditIncomeDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[3].HeaderText = "Артикул";
            EditIncomeDataGridView.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            EditIncomeDataGridView.Columns[4].HeaderText = "Количество";
            EditIncomeDataGridView.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[5].HeaderText = "Цена";
            EditIncomeDataGridView.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[6].HeaderText = "Ремонт";
            EditIncomeDataGridView.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditIncomeDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void EditIncome(object sender, DataGridViewCellMouseEventArgs e)
        {
            editId = int.Parse(EditIncomeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            EditArticle.Text = EditIncomeDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            EditQwantity.Text = EditIncomeDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            EditPrice.Text = EditIncomeDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            EditRepair.Text = EditIncomeDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (editId > 0)
            {
                if (EditArticle.Text != "")
                {
                    string priceString = "0";
                    string repairString = "0";
                    string quantityString = "1";

                    if (EditPrice.Text != "")
                    {
                        priceString = EditPrice.Text.ToString();
                    }
                    if (EditRepair.Text != "")
                    {
                        repairString = EditRepair.Text.ToString();
                    }
                    if (EditQwantity.Text != "")
                    {
                        quantityString = EditQwantity.Text.ToString();
                    }

                    for (int i = 0; i < priceString.Length; i++)
                    {
                        if (priceString[i] == ',')
                        {
                            string priStr1 = priceString.Substring(0, i);
                            string priStr2 = priceString.Substring(i + 1);
                            priceString = priStr1 + '.' + priStr2;
                        }
                    }
                    for (int i = 0; i < repairString.Length; i++)
                    {
                        if (repairString[i] == ',')
                        {
                            string repStr1 = repairString.Substring(0, i);
                            string repStr2 = repairString.Substring(i + 1);
                            repairString = repStr1 + '.' + repStr2;
                        }
                    }

                    var entity = techzone.Incomes.FirstOrDefault(X => X.Id == editId);
                    entity.Article = EditArticle.Text;
                    entity.Quantity = int.Parse(quantityString);
                    entity.Price = decimal.Parse(priceString);
                    entity.Repair = decimal.Parse(repairString);



                    if (DialogResult.Yes == MessageBox.Show("Сигурни ли сте че искате да редактирате този запис ?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        techzone.SaveChanges();
                        makeReference();

                        EditArticle.Text = "";
                        EditQwantity.Text = "1";
                        EditPrice.Text = "0";
                        EditRepair.Text = "0";
                        editId = 0;

                        MessageBox.Show("Редактирахте успешно Записа");
                    }
                }

                else
                {
                    EditArticle.Select();
                }
            }
            else
            {
                MessageBox.Show("Моля изберете ред");
            }

            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            if (editId > 0)
            {
                var entity = techzone.Incomes.FirstOrDefault(X => X.Id == editId);
                techzone.Incomes.Remove(entity);

                if (DialogResult.Yes == MessageBox.Show("Сигурни ли сте че искате да Изтриете този запис ?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    techzone.SaveChanges();
                    makeReference();

                    EditArticle.Text = "";
                    EditQwantity.Text = "1";
                    EditPrice.Text = "0";
                    EditRepair.Text = "0";
                    editId = 0;

                    MessageBox.Show("Изтрихте успешно Записа");
                }
            }
            else
            {
                MessageBox.Show("Моля изберете ред");
            }
                

        }
    }
}
