using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using AccountingSystem.Core.ViewModels;

namespace AccountingSystem.Service.IncomeStatments
{
    public class AccountingCalcForIncomeStatment
    {
        public IncomeStatment HandleExpenses(Expenses expenses, IncomeStatment lastIncomeStatment)
        {
            if(expenses.ExpensesEntry == ExpensesEntries.Advertising)
            {
                lastIncomeStatment.Advertising += expenses.ExpensesValue;
            }

             if (expenses.ExpensesEntry == ExpensesEntries.Rent)
            {
                lastIncomeStatment.Rent += expenses.ExpensesValue;

            }

            if (expenses.ExpensesEntry == ExpensesEntries.Salary)
            {
                lastIncomeStatment.Salary += expenses.ExpensesValue;

            }

            if (expenses.ExpensesEntry == ExpensesEntries.Utilities)
            {
                lastIncomeStatment.Utilities += expenses.ExpensesValue;

            }

            return lastIncomeStatment;
        }


        public IncomeStatment CalcIncomeStatmentTotal(IncomeStatment lastIncomeStatment)
        {
            lastIncomeStatment.Totall = lastIncomeStatment.SalesRevenue - (lastIncomeStatment.Salary
             + lastIncomeStatment.Rent + lastIncomeStatment.Utilities + lastIncomeStatment.Advertising);

            return lastIncomeStatment;
        }
    }
}
