using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using AccountingSystem.Core.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

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

      
    
        
        public void UpdateLastBalance()
        {
            //get last balance
            Balance lastBalance = balanceRepo.GetLastBalance().Result;
            //get all transactions
            IEnumerable<Transaction> transactions = transactionRepo.GetAll().Result;
            //Edit last balance
            accountingCalcForBalance.EditLastBalance(transactions, lastBalance);
            //Send Updated Balance to database
            balanceRepo.Update(lastBalance);
        }

        public void CreateNewBalance(Balance balance)
        {
            balance.Date = DateTime.Now;
            balanceRepo.Create(balance);

        }


    }
}


  //foreach (var possibleTransaction in Enum.GetNames(typeof(PossibleTransactions)))
  //              {
  //                  //make it dynamic for all possible transactions
  //                  if (transaction.DrTransactionEntry.ToString() == possibleTransaction)
  //                  {
  //                      lastBalance.Cash += transaction.DrTransactionEntryValue;
  //                  }
  //              }