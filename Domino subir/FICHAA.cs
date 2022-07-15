using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ficha
{
    public  class FICHA
    {
        public int num1 { set; get; }
        public int num2 { set; get; }
        public FICHA(int n1, int n2)
        {
            num1 = n1;
            num2 = n2;
        }
    }
}
