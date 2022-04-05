// Никольникова Полина ПММ, 2 курс, 91 группа
// 1 лабораторная работа
// 15. Создать объект класса Год, используя классы Месяц, День.
// Методы: задать дату, вывести день недели по заданной дате, рассчитать количество дней, месяцев в заданном временном промежутке.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_лабораторная
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
