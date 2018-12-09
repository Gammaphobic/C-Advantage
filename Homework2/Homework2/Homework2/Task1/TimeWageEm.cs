using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class TimeWageEm:Employees
    {
        private decimal hourlyRate;
        private decimal dayCount=20.8M;
        private decimal hourCount=8;
        protected override decimal AMW()
        {
            AverageMonthWages = hourlyRate * dayCount*hourCount;
            return AverageMonthWages;
        }
    }
}
