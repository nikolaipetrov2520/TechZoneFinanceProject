using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DataBase.Model;
using iTech.Model;

namespace iTech
{
    public partial class iTech : Form
    {
        //private List<string> list;
        private List<string> costList;
        private List<RefIncome> incomeList;
        private List<RefCost> costPrintList;
        private List<RefIncome> dateIncomeList;
        private TechZoneContext techzone = new TechZoneContext();
        public iTech()
        {
            //list = new List<string>();
            costList = new List<string>();
            incomeList = new List<RefIncome>();
            costPrintList = new List<RefCost>();
            dateIncomeList = new List<RefIncome>();
            InitializeComponent();
            tabControl1.SelectedTab = tab1;
            tabControl2.SelectedTab = reference1;
            string date = DateTime.Now.ToShortDateString();
            sum.Text = IncomForDay(date);
            costForDayBox.Text = CostForDay(date);
            GetIncomsForDay(date);
            GetCostForDay(date);
            articleBox.Select();
            cashBox.Text = GetCash();
            cash2Box.Text = GetCash2();
        }

        private List<RefCost> GetCostForDay(string date)
        {
            costPrintList.Clear();

            var dateNow = DateTime.Now.Date;

            costPrintList = techzone.Costs
                 .Where(x => x.Date == dateNow)
                 .Select(x => new RefCost
                 {
                     Date = x.Date,
                     Sum = x.Sum,
                     Name = x.Name
                 })
                 .ToList();

            //string[] line = File.ReadAllLines(costPath);
            //for (int i = 0; i < line.Length; i++)
            //{
            //    if (line[i].Contains(date))
            //    {
            //        string[] arr = line[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //        string[] arr2 = arr[1].Split('@', StringSplitOptions.RemoveEmptyEntries);
            //      //  Cost cost = new Cost(arr[0], arr2[0], $"{decimal.Parse(arr2[1]):f2}лв.");
            //      // costPrintList.Add(cost);
            //    }
            //}
            refferenceCostBox.DataSource = null;
            refferenceCostBox.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            refferenceCostBox.EnableHeadersVisualStyles = false;
            refferenceCostBox.DataSource = costPrintList;
            return costPrintList;

        }

        private List<RefIncome> GetIncomsForDay(string date)
        {
            incomeList.Clear();

            var dateNow = DateTime.Now.Date;          

            incomeList = techzone.Incomes
                 .Where(x => x.Date == dateNow)
                 .Select(x => new RefIncome
                 {
                     Date = x.Date,
                     Article = x.Article,
                     Quantity = x.Quantity,
                     Price = x.Price,
                     Repair = x.Repair
                 })
                 .ToList();



            //string[] line = File.ReadAllLines(incomePath);
            //for (int i = 0; i < line.Length; i++)
            //{
            //    if (line[i].Contains(date))
            //    {
            //        string[] arr = line[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //        string[] arr2 = arr[1].Split('@', StringSplitOptions.RemoveEmptyEntries);
            //       // Income income = new Income(arr[0], arr2[0], int.Parse(arr2[1]), $"{decimal.Parse(arr2[2]):f2}лв.", $"{decimal.Parse(arr2[3]):f2}лв.");
            //       // incomeList.Add(income);
                    
            //    }
            //}
            refferenceIncomeBox.DataSource = null;
            refferenceIncomeBox.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            refferenceIncomeBox.EnableHeadersVisualStyles = false;
            refferenceIncomeBox.DataSource = incomeList;
            return incomeList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
  
        private void submit_Click(object sender, EventArgs e)
        {
            if (articleBox.Text != "")
            {
                string priceString = "0";
                string repairString = "0";
                string quantityString = "1";

                if (priceBox.Text != "")
                {
                    priceString = priceBox.Text.ToString();
                }
                if (repairBox.Text != "")
                {
                    repairString = repairBox.Text.ToString();
                }
                if (quantityBox.Text != "")
                {
                    quantityString = quantityBox.Text.ToString();
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

                var entity = new Income
                {
                    Date = DateTime.Now,
                   Article = articleBox.Text,
                   Quantity = int.Parse(quantityString),
                   Price = decimal.Parse(priceString),
                   Repair = decimal.Parse(repairString)
                };


                //list.Add(articleBox.Text);
                //list.Add(quantityString);
                //list.Add(priceString);
                //list.Add(repairString);

                //string result = (int.Parse(list[1]) * (decimal.Parse(list[2]) + decimal.Parse(list[3]))).ToString();

                SaveLineIncome(entity);
            }
            else
            {
                articleBox.Select();
            }
           
        }

        private void SaveLineIncome(Income entity)
        {
            techzone.Incomes.Add(entity);
            techzone.SaveChanges();


            string date = DateTime.Now.ToShortDateString();

            //File.AppendAllText(incomePath, $"{date}|{String.Join("@", list)}|{result}{Environment.NewLine}");

            sum.Text = IncomForDay(date);
            GetRefferenceIncomeBoxData(date);
            //list.Clear();
            cashBox.Text = GetCash();
            articleBox.Text = "";
            quantityBox.Text = "1";
            priceBox.Text = "0";
            repairBox.Text = "0";
            
        }

        private void GetRefferenceIncomeBoxData(string date)
        {
            refferenceIncomeBox.DataSource = null;
            List<RefIncome> list = GetIncomsForDay(date);
            refferenceIncomeBox.DataSource = list;
            refferenceIncomeBox.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;      
            refferenceIncomeBox.Columns[0].HeaderText = "Дата";
            refferenceIncomeBox.Columns[1].HeaderText = "Артикул";
            refferenceIncomeBox.Columns[2].HeaderText = "Брой";
            refferenceIncomeBox.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            refferenceIncomeBox.Columns[3].HeaderText = "Цена";
            refferenceIncomeBox.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            refferenceIncomeBox.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            refferenceIncomeBox.Columns[4].HeaderText = "Ремонт";
            refferenceIncomeBox.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            refferenceIncomeBox.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


        }

        private void GetRefferenceCostBoxData(string date)
        {
            refferenceCostBox.DataSource = null;
            List<RefCost> list = GetCostForDay(date);
            refferenceCostBox.DataSource = list;         
            refferenceCostBox.Columns[0].HeaderText = "Дата";
            refferenceCostBox.Columns[1].HeaderText = "Име";
            refferenceCostBox.Columns[2].HeaderText = "Сума";
            refferenceCostBox.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            refferenceCostBox.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


        }

        private void articleBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                quantityBox.Select();
            }  
        }

        private void quantityBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                priceBox.Select();
            }
        }

        private void priceBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                repairBox.Select();
            }
        }

        private void repairBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                submit_Click(sender, e);
                submit.Select();
                articleBox.Select();
            }
        }
        private void submit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                submit_Click(sender, e);
            }
        }

        private void costNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                costSumBox.Select();
            }
        }

        private void costSumBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                costSubmit_Click(sender, e);
                costSubmit.Select();
                costNameBox.Select();
            }
        }

        private void costSubmit_Click(object sender, EventArgs e)
        {
            if (costNameBox.Text != "")
            {
                string costSumString = "0";
                if (costSumBox.Text != "")
                {
                    costSumString = costSumBox.Text.ToString();
                }

                for (int i = 0; i < costSumString.Length; i++)
                {
                    if (costSumString[i] == ',')
                    {
                        string cSStr1 = costSumString.Substring(0, i);
                        string cSStr2 = costSumString.Substring(i + 1);
                        costSumString = cSStr1 + '.' + cSStr2;
                    }
                }


                var entity = new Cost
                {
                    Date = DateTime.Now,
                    Name = costNameBox.Text,
                    Sum = decimal.Parse(costSumString)
                };

                //costList.Add(costNameBox.Text);
                //costList.Add(costSumString);

                //string result = (decimal.Parse(costList[1])).ToString();

                SaveLineCost(entity);
            }
            else
            {
                costNameBox.Select();
            }
            
            
        }

        private void costSubmit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                costSubmit_Click(sender, e);
            }
        }

        private void SaveLineCost(Cost entity)
        {
            techzone.Costs.Add(entity);
            techzone.SaveChanges();


            string date = DateTime.Now.ToShortDateString();

            //File.AppendAllText(costPath, $"{date}|{String.Join('@', list)}|{result}{Environment.NewLine}");

            costForDayBox.Text = CostForDay(date);
            GetRefferenceCostBoxData(date);
            costList.Clear();
            cashBox.Text = GetCash();
            costNameBox.Text = "";
            costSumBox.Text = "0";
        }

        private string CostForDay(string date)
        {

            //string[] line = File.ReadAllLines(costPath);
            decimal sum = 0;
            //for (int i = 0; i < line.Length; i++)
            //{
            //    if (line[i].Contains(date))
            //    {
            //        string[] arr = line[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //        sum += decimal.Parse(arr[2]);

            //    }
            //}
            var dateNow = DateTime.Now.Date;

            var costs = techzone.Costs
                .Where(x => x.Date == dateNow)
                .Select(x => x.Sum)
                 .ToList()                 
                 .Sum();

            sum = (decimal)costs;
            costReferenceBox.Text = sum.ToString();
            return sum.ToString();
        }

        private string IncomForDay(string date)
        {

            //string[] line = File.ReadAllLines(incomePath);
            decimal sum = 0;
            decimal incomeSum = 0;
            decimal repairSum = 0;           

            var dateNow = DateTime.Now.Date;

           var entitys = techzone.Incomes
                .Where(x => x.Date == dateNow)
                .ToList();

            foreach (var entity in entitys)
            {
                incomeSum += (decimal)(entity.Quantity * entity.Price);
                repairSum += (decimal)(entity.Quantity * entity.Repair);
            }

            sum += incomeSum + repairSum;

            //for (int i = 0; i < line.Length; i++)
            //{
            //    if (line[i].Contains(date))
            //    {
            //        string[] arr = line[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //        string[] arr2 = arr[1].Split('@', StringSplitOptions.RemoveEmptyEntries);
            //        quantity = int.Parse(arr2[1]);
            //        incomeSum += quantity * decimal.Parse(arr2[2]);
            //        repairSum += quantity * decimal.Parse(arr2[3]);

            //        sum += decimal.Parse(arr[2]);
            //    }
            //}
            incomeSumBox.Text = incomeSum.ToString();
            incomeRepairBox.Text = repairSum.ToString();
            return sum.ToString();
        }

        private void quantityBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void priceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void repairBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void costSumBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void makeReference_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(dateStart.Text);
            DateTime endDate = DateTime.Parse(dateEnd.Text);
            dateIncomeList.Clear();
           // string[] line = File.ReadAllLines(incomePath);
            int startIndex = -1;
            int endIndex = -1;
            //int quantity = 1;
            decimal sumIncome = 0;
            decimal sumRepair = 0;

            dateIncomeList = techzone.Incomes
                .Where(x => x.Date >= startDate && x.Date <= endDate)
                .Select(x => new RefIncome
                {
                    Date = x.Date,
                    Article = x.Article,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Repair = x.Repair
                })
                .ToList();

            foreach (var entity in dateIncomeList)
            {
                sumIncome += (decimal)(entity.Quantity * entity.Price);
                sumRepair += (decimal)(entity.Quantity * entity.Repair);
            }

            //for (int i = 0; i < line.Length; i++)
            //{
            //    if (line[i].Contains(startDate))
            //    {
            //        startIndex = i;
            //        break;
            //    }
            //}
            //for (int i = 0; i < line.Length; i++)
            //{
            //    if (line[i].Contains(endDate))
            //    {
            //        endIndex = i;
            //    }
            //}
            //if (startIndex > 0 && endIndex > 0 && startIndex <= line.Length && endIndex <= line.Length)
            //{
            //    for (int i = startIndex; i <= endIndex; i++)
            //    {

            //        string[] arr = line[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //        string[] arr2 = arr[1].Split('@', StringSplitOptions.RemoveEmptyEntries);
            //        //Income income = new Income(arr[0], arr2[0], int.Parse(arr2[1]), $"{decimal.Parse(arr2[2]):f2}лв.", $"{decimal.Parse(arr2[3]):f2}лв.");
            //       // quantity = int.Parse(arr2[1]);
            //        //sumIncome += quantity * decimal.Parse(arr2[2]);
            //       // sumRepair += quantity * decimal.Parse(arr2[3]);
            //       // dateIncomeList.Add(income);                 
            //    }
                dateBox.DataSource = null;
                dateBox.DataSource = dateIncomeList;
                dateBox.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
                dateBox.DefaultCellStyle.ForeColor = Color.Black;
                dateBox.EnableHeadersVisualStyles = false;
                dateBox.Columns[0].Width = 118;
                dateBox.Columns[0].HeaderText = "Дата";
                dateBox.Columns[1].Width = 340;
                dateBox.Columns[1].HeaderText = "Артикул";
                dateBox.Columns[2].Width = 60;
                dateBox.Columns[2].HeaderText = "Брой";
                dateBox.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dateBox.Columns[3].HeaderText = "Цена";
                dateBox.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dateBox.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dateBox.Columns[4].HeaderText = "Ремонт";
                dateBox.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dateBox.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dateIncomeBox.Text = sumIncome.ToString();
                dateRepairBox.Text = sumRepair.ToString();
                totalBox.Text = (sumIncome + sumRepair).ToString();
            //}
            //else
            //{
            //    dateBox.DataSource = "За избраната дата няма данни. Моля изберете друга дата.";
            //}
           

        }

        private string GetCash()
        {
            decimal sumIncom = 0;
            decimal incomeSum = 0;
            decimal repairSum = 0;

           

            var incoms = techzone.Incomes                 
                 .ToList();

            foreach (var incom in incoms)
            {
                incomeSum += (decimal)(incom.Quantity * incom.Price);
                repairSum += (decimal)(incom.Quantity * incom.Repair);
            }

            sumIncom += incomeSum + repairSum;

            var costs = techzone.Costs
                .Select(x => x.Sum)
                 .ToList()
                 .Sum();



            decimal cash = 0m;

            cash = (decimal)(sumIncom - costs);


            //string[] lineIncome = File.ReadAllLines(incomePath);
            //string[] lineCost = File.ReadAllLines(costPath);

            //cash += decimal.Parse(lineIncome[0]);
            //for (int i = 1; i < lineIncome.Length; i++)
            //{
            //    string[] arr = lineIncome[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //    decimal currentIncome = decimal.Parse(arr[arr.Length - 1]);
            //    cash += currentIncome;
            //}
            //for (int i = 0; i < lineCost.Length; i++)
            //{
            //    string[] arr = lineCost[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //    decimal currentCost = decimal.Parse(arr[arr.Length - 1]);
            //    cash -= currentCost;
            //}



            return $"{cash:f2}".ToString();
        }

        private void cash2InBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cash2InBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cash2OutBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cash2InBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                cash2InButton_Click(sender, e);
                cash2InButton.Select();
                cash2InBox.Text = "";
                cash2InBox.Select();
            }

        }

        private void cash2OutBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                cash2OutButton_Click(sender, e);
                cash2OutButton.Select();
                cash2OutBox.Text = "";
                cash2OutBox.Select();
            }
        }

        private void cash2InButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                cash2InButton_Click(sender, e);
            }

        }

        private void cash2OutButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                cash2OutButton_Click(sender, e);
            }

        }

        private void cash2InButton_Click(object sender, EventArgs e)
        {
            if (cash2InBox.Text != "")
            {              
                string cash2 = cash2InBox.Text.ToString();

                for (int i = 0; i < cash2.Length; i++)
                {
                    if (cash2[i] == ',')
                    {
                        string c2Str1 = cash2.Substring(0, i);
                        string c2Str2 = cash2.Substring(i + 1);
                        cash2 = c2Str1 + '.' + c2Str2;
                    }
                }
                //?
                string date = DateTime.Now.ToShortDateString();

                decimal cash2Sum = decimal.Parse(cash2);

                var entity = new Cash2
                {
                    Date = DateTime.Now,
                    Money = cash2Sum

                };
                techzone.Cash2s.Add(entity);
                techzone.SaveChanges();

                //File.AppendAllText(cash2Path, $"{date}|{cash2}{Environment.NewLine}");
                File.AppendAllText(costPath, $"{date}|Прехвърлени към Каса 2@{cash2}|{cash2}{Environment.NewLine}");
                cashBox.Text = GetCash();
                costForDayBox.Text = CostForDay(date);
                GetRefferenceCostBoxData(date);
            }
            else
            {
                cash2InBox.Select();
            }
            cash2InBox.Text = "";
            cash2Box.Text = GetCash2();
        }

        private void cash2OutButton_Click(object sender, EventArgs e)
        {
            if (cash2OutBox.Text != "")
            {
                string cash2 = cash2OutBox.Text.ToString();

                for (int i = 0; i < cash2.Length; i++)
                {
                    if (cash2[i] == ',')
                    {
                        string c2Str1 = cash2.Substring(0, i);
                        string c2Str2 = cash2.Substring(i + 1);
                        cash2 = c2Str1 + '.' + c2Str2;
                    }
                }
                //?
                string date = DateTime.Now.ToShortDateString();
              
                decimal cash2Sum = decimal.Parse(cash2);

                var entity = new Cash2
                {
                    Date = DateTime.Now,
                    Money = -cash2Sum

                };
                techzone.Cash2s.Add(entity);
                techzone.SaveChanges();

                //File.AppendAllText(cash2Path, $"{date}|-{cash2}{Environment.NewLine}");
                File.AppendAllText(incomePath, $"{date}|Прехвърлени от Каса 2@1@{cash2}@0|{cash2}{Environment.NewLine}");
                cashBox.Text = GetCash();
                sum.Text = IncomForDay(date);
                GetRefferenceIncomeBoxData(date);
            }
            else
            {
                cash2OutBox.Select();
            }
            cash2OutBox.Text = "";
            cash2Box.Text = GetCash2();
        }

        private string GetCash2()
        {
            decimal cash = 0m;

            cash = (decimal)techzone.Cash2s.Sum(x => x.Money);
            //string[] lineCash2 = File.ReadAllLines(cash2Path);

            //for (int i = 0; i < lineCash2.Length; i++)
            //{
            //    string[] arr = lineCash2[i].Split('|', StringSplitOptions.RemoveEmptyEntries);
            //    decimal currentCash2 = decimal.Parse(arr[1]);
            //    cash += currentCash2;
            //}
            return $"{cash:f2}".ToString();
        }
    }
}
