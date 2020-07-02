using AccountingSystem.Core.Entities;
using AccountingSystem.Core.IRepo;
using AccountingSystem.Core.ViewModels;
using AccountingSystem.Service.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Service.IncomeStatments
{
    public class IncomeStatmentService
    {

        public IncomeStatmentService( AccountingCalcForIncomeStatment accountingCalcForIncomeStatment,IIncomeStatmentRepo incomeStatmentRepo,BalanceService balanceService)
        {
            this.accountingCalcForIncomeStatment = accountingCalcForIncomeStatment;
            this.incomeStatmentRepo = incomeStatmentRepo;
            this.balanceService = balanceService;
        }
        private readonly IIncomeStatmentRepo incomeStatmentRepo;
        private readonly BalanceService balanceService;
        private readonly AccountingCalcForIncomeStatment accountingCalcForIncomeStatment;

        public IncomeStatmentService(IIncomeStatmentRepo incomeStatmentRepo )
        {
            this.incomeStatmentRepo = incomeStatmentRepo;
        }
        public async Task updateincomestatmentWithExpenses(Expenses expensesVM)
        {
            //get last Income Statment
            IncomeStatment lastIncomeStatment = await incomeStatmentRepo.GetLastIncomeStatment();

            //Add expenses
            lastIncomeStatment = accountingCalcForIncomeStatment.HandleExpenses(expensesVM, lastIncomeStatment);

            // update totall ForIncomeStatment
            accountingCalcForIncomeStatment.CalcIncomeStatmentTotal(lastIncomeStatment);

            //TODO decrease balance cash with this expenses
            //TODO Affect cash & capital in balance sheet
            await balanceService.UpdateLastBalanceCashWithExpenses(expensesVM);

            // update totall ForIncomeStatment
            accountingCalcForIncomeStatment.CalcIncomeStatmentTotal(lastIncomeStatment);
     
            //update database
            await incomeStatmentRepo.Update(lastIncomeStatment);

        }

        public async Task updateincomestatmentWithRevenue(double CrTransactionEntryOfGoods)
        {
            //get last Income Statment
            IncomeStatment lastIncomeStatment = await incomeStatmentRepo.GetLastIncomeStatment();

            //Add Revenue
            lastIncomeStatment.SalesRevenue += CrTransactionEntryOfGoods * 0.3;

            //TODO Affect cash & capital in balance sheet
            await balanceService.UpdateLastBalanceCashWithRevenues(lastIncomeStatment);
            
            // update totall
            accountingCalcForIncomeStatment.CalcIncomeStatmentTotal(lastIncomeStatment);

            //update database
            await incomeStatmentRepo.Update(lastIncomeStatment);
        }

        public async Task CreateNewIncomeStatment( )
        {

            IncomeStatment incomeStatment = new IncomeStatment()
            {
                Advertising = 0,
                Rent = 0,
                Salary = 0,
                SalesRevenue = 0,
                Totall = 0,
                Utilities = 0,
                Date = DateTime.Now
            };
            
            await incomeStatmentRepo.Update(incomeStatment);
        }


        
    }
}
