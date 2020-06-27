using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using AccountingSystem.Core.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Service.Balances
{
    public class BalanceService
    {
        private readonly ITransactionRepo transactionRepo;
        private readonly IBalanceRepo balanceRepo;
        private readonly AccountingCalcForBalance accountingCalcForBalance;

        public BalanceService(ITransactionRepo transactionRepo, IBalanceRepo balanceRepo, AccountingCalcForBalance accountingCalcForBalance)
        {
            this.transactionRepo = transactionRepo;
            this.balanceRepo = balanceRepo;
            this.accountingCalcForBalance = accountingCalcForBalance;
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

        public async Task CreateNewBalance(Balance balance)
        {
            balance.Date = DateTime.Now;
            await balanceRepo.Create(balance);

        }


    }
}

