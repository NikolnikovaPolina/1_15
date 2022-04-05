using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_лабораторная
{
    [Serializable]
    public class Month
    {
        public string month = "";
        
        public Month(string month) => this.month = month;
    }
}
