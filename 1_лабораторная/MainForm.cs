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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Day_of_the_week_Click(object sender, EventArgs e)
        {
            Year year = new Year(1);
            DateForm form = new DateForm(year);
            form.ShowDialog();
        }

        private void Interval_Click(object sender, EventArgs e)
        {
            Year year1 = new Year(1);
            Year year2 = new Year(1);
            FormInterval form = new FormInterval(year1, year2);
            form.ShowDialog();
        }

        private void Condition_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создать объект класса Год, используя классы Месяц, День.\n" +
                "Методы: задать дату, вывести день недели по заданной дате, рассчитать количество дней, месяцев в заданном временном промежутке.",
                "Задача 15", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
