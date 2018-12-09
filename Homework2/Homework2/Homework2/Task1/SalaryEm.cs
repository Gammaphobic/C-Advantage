using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class SalaryEm : Employees
    {
        private decimal salary;
        protected override decimal AMW()
        {
            AverageMonthWages = salary;
            return AverageMonthWages;

        }
    }
}
