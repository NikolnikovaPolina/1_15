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
    public partial class FormInterval : Form
    {
        public FormInterval(Year year1, Year year2)
        {
            InitializeComponent();
            NumDay1.Value = year1.day.day;
            MonthsBox1.Text = year1.month.month;
            NumYear1.Value = year1.year;
            NumDay2.Value = year2.day.day;
            MonthsBox2.Text = year2.month.month;
            NumYear2.Value = year2.year;
        }


        public Year year1 = new Year();
        public Year year2 = new Year();

        private void Button_calculate_Click(object sender, EventArgs e)
        {
            year1.day = new Day((int)NumDay1.Value);
            year1.month = new Month(MonthsBox1.Text);
            year1.year = (int)NumYear1.Value;
            year2.day = new Day((int)NumDay2.Value);
            year2.month = new Month(MonthsBox2.Text);
            year2.year = (int)NumYear2.Value;

            if (((int)NumYear1.Value % 4 == 0 && MonthsBox1.Text == "Февраль" && (int)NumDay1.Value > 29) || ((int)NumYear1.Value % 4 != 0 &&
                MonthsBox1.Text == "Февраль" && (int)NumDay1.Value > 28) || ((MonthsBox1.Text == "Апрель" || MonthsBox1.Text == "Июнь" ||
                MonthsBox1.Text == "Сентябрь" || MonthsBox1.Text == "Ноябрь") && (int)NumDay1.Value == 31))
            {
                MessageBox.Show("Неправильный ввод первой даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (((int)NumYear2.Value % 4 == 0 && MonthsBox2.Text == "Февраль" && (int)NumDay2.Value > 29) || ((int)NumYear2.Value % 4 != 0 &&
                MonthsBox2.Text == "Февраль" && (int)NumDay2.Value > 28) || ((MonthsBox2.Text == "Апрель" || MonthsBox2.Text == "Июнь" ||
                MonthsBox2.Text == "Сентябрь" || MonthsBox2.Text == "Ноябрь") && (int)NumDay2.Value == 31))
            {
                MessageBox.Show("Неправильный ввод второй даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                string interval = year1.Calculate_interval(year2);
                MessageBox.Show(interval, "Интервал", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
