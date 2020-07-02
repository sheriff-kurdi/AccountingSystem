using AccountingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Core.ViewModels
{
    public class Expenses
    {
        public double ExpensesValue { get; set; }
        public Enums.ExpensesEntries ExpensesEntry { get; set; }
    }
}

