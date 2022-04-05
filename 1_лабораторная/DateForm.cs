using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_лабораторная
{
    public partial class DateForm : Form
    {
        public DateForm(Year year)
        {
            InitializeComponent();
            NumDay.Value = year.day.day;
            MonthsBox.Text = year.month.month;
            NumYear.Value = year.year;
        }

        public Year year = new Year();

        private void Btn_calculate_Click(object sender, EventArgs e)
        {
            year.day = new Day((int)NumDay.Value);
            year.month = new Month(MonthsBox.Text);
            year.year = (int)NumYear.Value;
           
            if(((int)NumYear.Value % 4 == 0 && MonthsBox.Text == "Февраль" && (int)NumDay.Value > 29) || ((int)NumYear.Value % 4 != 0 &&
                MonthsBox.Text == "Февраль" && (int)NumDay.Value > 28) || ((MonthsBox.Text == "Апрель" || MonthsBox.Text == "Июнь" ||
                MonthsBox.Text == "Сентябрь" || MonthsBox.Text == "Ноябрь") && (int)NumDay.Value == 31))
            {
                MessageBox.Show("Неправильный ввод даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                string day_of_the_week = year.Calculate_day();
                MessageBox.Show(day_of_the_week, "День недели", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}