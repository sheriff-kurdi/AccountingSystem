using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using AccountingSystem.Core.IRepo;
using AccountingSystem.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Service.Balances
{
    public class BalanceService
    {
        private readonly IBalanceRepo balanceRepo;
        private readonly AccountingCalcForBalance accountingCalcForBalance;
        private readonly IIncomeStatmentRepo incomeStatmentRepo;

        public BalanceService( IBalanceRepo balanceRepo,  AccountingCalcForBalance accountingCalcForBalance, IIncomeStatmentRepo incomeStatmentRepo)
        {
            this.balanceRepo = balanceRepo;
            this.accountingCalcForBalance = accountingCalcForBalance;
            this.incomeStatmentRepo = incomeStatmentRepo;
        }

      
    
        
        public async Task UpdateLastBalance(Transaction transaction)
        {
            
            //get last balance
            Balance lastBalance = await balanceRepo.GetLastBalance();

            //get all transactions onlu if you want to calc for all table transactions
            //IEnumerable<Transaction> transactions = transactionRepo.GetAll().Result;

            //Edit last balance
            lastBalance = accountingCalcForBalance.EditLastBalance(transaction, lastBalance);
            //Send Updated Balance to database
            await balanceRepo.Update(lastBalance);
        }

        public async Task UpdateLastBalanceCashWithExpenses(Expenses expenses)
        {

            //TODO Affect cash & capital in balance sheet
            //get last balance
            var lastBalance = await balanceRepo.GetLastBalance();
            lastBalance.Capital -= expenses.ExpensesValue;
            lastBalance.Cash -= expenses.ExpensesValue;
            await balanceRepo.Update(lastBalance);
            //**************************************************************

            // calc balace Totall
            lastBalance.TotalAsset = accountingCalcForBalance.CalculateTotalBalance(lastBalance).TotalAsset;
            lastBalance.TotallLiabilityAndEquity = accountingCalcForBalance.CalculateTotalBalance(lastBalance).TotallLiabilityAndEquity;
            //...............
        }

        public async Task UpdateLastBalanceCashWithRevenues(IncomeStatment lastIncomeStatment)
        {
            //TODO Affect cash & capital in balance sheet
            //get last balance
            var lastBalance = await balanceRepo.GetLastBalance();
            lastBalance.Capital += lastIncomeStatment.SalesRevenue;
            lastBalance.Cash += lastIncomeStatment.SalesRevenue;
            await balanceRepo.Update(lastBalance);
            //**************************************************************

        }

        public async Task CreateNewBalance(Balance balance)
        {
            balance.Date = DateTime.Now;
            await balanceRepo.Create(balance);

        }


    }
}

