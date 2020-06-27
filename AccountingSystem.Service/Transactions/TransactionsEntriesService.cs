using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using AccountingSystem.Core.IRepo;
using AccountingSystem.Service.Balances;

namespace AccountingSystem.Service.Transactions
{
    public class TransactionsEntriesService
    {
        private readonly ITransactionRepo transactionRepo;
        private readonly BalanceService balanceService;

        public TransactionsEntriesService(ITransactionRepo transactionRepo, BalanceService balanceService)
        {
            this.transactionRepo = transactionRepo;
            this.balanceService = balanceService;
        }

        public async Task CreateTransaction(Transaction transaction)
        {
            // calc A/R Or A/P
            if (transaction.DrTransactionEntryValue > transaction.CrTransactionEntryValue)
            {
                // A/P
                transaction.AccountPyable = transaction.DrTransactionEntryValue - transaction.CrTransactionEntryValue;
            }
            else
            {
                // A/R
                transaction.AccountReceivable = transaction.CrTransactionEntryValue - transaction.DrTransactionEntryValue;

            }

            transaction.Date = DateTime.Now;


            await transactionRepo.Create(transaction);

            await balanceService.UpdateLastBalance(transaction);
       
            // Add To database
        }
    }
}
