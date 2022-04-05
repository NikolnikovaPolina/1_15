using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_лабораторная
{
    [Serializable]
    public class Year
    {
        public Day day;
        public Month month;
        public int year;

        public Year()
        { }

        public Year(int year)
        {
            this.year = year;
            month = new Month("Январь");
            day = new Day(1);
        }

        private int Code_year()
        {
            int code_year;

            if (year / 100 == 20 || year / 100 == 16 || year / 100 == 12 || year / 100 == 8 || year / 100 == 4 || year / 100 == 0)
            {
                code_year = 6;
            }
            else if (year / 100 == 21 || year / 100 == 17 || year / 100 == 13 || year / 100 == 9 || year / 100 == 5 || year / 100 == 1)
            {
                code_year = 4;
            }
            else if (year / 100 == 22 || year / 100 == 18 || year / 100 == 14 || year / 100 == 10 || year / 100 == 6 || year / 100 == 2)
            {
                code_year = 2;
            }
            else
            {
                code_year = 0;
            }

            return code_year;
        }

        private int Code_month()
        {
            int code_month;
          
            if ((year % 4 == 0 && month.month == "Январь") || month.month == "Апрель" || month.month == "Июль")
            {
                code_month = 0;
            }
            else if ((year % 4 != 0 && month.month == "Январь") || month.month == "Октябрь")
            {
                code_month = 1;
            }
            else if (month.month == "Май")
            {
                code_month = 2;
            }
            else if ((year % 4 == 0 && month.month == "Февраль") || month.month == "Август")
            {
                code_month = 3;
            }
            else if ((year % 4 != 0 && month.month == "Февраль") || month.month == "Март" || month.month == "Ноябрь")
            {
                code_month = 4;
            }
            else if (month.month == "Июнь")
            {
                code_month = 5;
            }
            else
            {
                code_month = 6;
            }

            return code_month;
        }

        private string Day_of_the_week(int code_day)
        {
            string day_of_the_week;

            if (code_day == 0)
            {
                day_of_the_week = "Суббота";
            }
            else if (code_day == 1)
            {
                day_of_the_week = "Воскресенье";
            }
            else if (code_day == 2)
            {
                day_of_the_week = "Понедельник";
            }
            else if (code_day == 3)
            {
                day_of_the_week = "Вторник";
            }
            else if (code_day == 4)
            {
                day_of_the_week = "Среда";
            }
            else if (code_day == 5)
            {
                day_of_the_week = "Четверг";
            }
            else
            {
                day_of_the_week = "Пятница";
            }

            return day_of_the_week;
        }

        public string Calculate_day()
        {
            int code_year = Code_year();
            int code_month = Code_month();
            int code_day = (day.day + code_month + code_year) % 7;
            
            return Day_of_the_week(code_day);
        }

        private int Search_for_the_month(Month month)
        {
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            int i = 0;
           
            while (months[i] != month.month)
            {
                i++;
            }
           
            return i;
        }

        private int Compare_strings(Month month1, Month month2)
        {
            int str1 = Search_for_the_month(month1);
            int str2 = Search_for_the_month(month2);

            return str1 - str2;
        }

        private int Dday(int dday, ref int dmonth)
        {
            dmonth--;
            Search_for_the_month(month);
            
            if (month.month == "Февраль" || month.month == "Апрель" || month.month == "Июнь" || month.month == "Август" ||
               month.month == "Сентябрь" || month.month == "Ноябрь" || month.month == "Январь")
            {
                dday += 31;
            }
            else if (this.year % 4 == 0 && month.month == "Март")
            {
                dday += 29;
            }
            else if (this.year % 4 != 0 && month.month == "Март")
            {
                dday += 28;
            }
            else
            {
                dday += 30;
            }

            return dday;
        }

        private int Compare_years(Year year, ref int dmonth, ref int dday)
        {
            int dyear = this.year - year.year;
            dmonth = Compare_strings(month, year.month);
            
            if (dmonth == 0)
            {
                dday = day.day - year.day.day;
                
                if (dday < 0)
                {
                    dyear--;
                    dmonth += 12;
                    dday = Dday(dday, ref dmonth);
                }
            }
            else if (dmonth > 0)
            {
                dday = day.day - year.day.day;
              
                if (dday < 0)
                {
                    dday = Dday(dday, ref dmonth);
                }
            }
            else
            {
                dyear--;
                dmonth += 12;
                dday = day.day - year.day.day;
                
                if (dday < 0)
                {
                    dday = Dday(dday, ref dmonth);
                }
            }

            return dyear;
        }
        public string Calculate_interval(Year year)
        {
            int dyear;
            int dmonth = 0;
            int dday = 0;

            if (this.year == year.year)
            {
                dyear = 0;
                dmonth = Compare_strings(month, year.month);
                
                if (dmonth == 0)
                {
                    dday = day.day - year.day.day;
                    
                    if (dday < 0)
                    {
                        dday *= (-1);
                    }
                }
                else if (dmonth > 0)
                {
                    dday = day.day - year.day.day;
                    
                    if (dday < 0)
                    {
                        dday = Dday(dday, ref dmonth);
                    }
                }
                else
                {
                    dmonth = -dmonth;
                    dday = year.day.day - day.day;
                    
                    if (dday < 0)
                    {
                        dday = year.Dday(dday, ref dmonth);
                    }
                }
            }
            else if (this.year > year.year)
            {
                dyear = Compare_years(year, ref dmonth, ref dday);
            }
            else
            {
                dyear = year.Compare_years(year, ref dmonth, ref dday);
            }
            
            dmonth += dyear * 12;
            string interval = "Количество месяцев: " + dmonth + "\nКоличество дней: " + dday;
            return interval;
        }
    }
}