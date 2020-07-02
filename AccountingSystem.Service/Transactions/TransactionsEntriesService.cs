using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using AccountingSystem.Core.IRepo;
using AccountingSystem.Service.Balances;
using AccountingSystem.Service.IncomeStatments;

namespace AccountingSystem.Service.Transactions
{
    public class TransactionsEntriesService
    {
        private readonly ITransactionRepo transactionRepo;
        private readonly BalanceService balanceService;
        private readonly IncomeStatmentService incomeStatmentService;

        public TransactionsEntriesService( ITransactionRepo transactionRepo, BalanceService balanceService,  IncomeStatmentService incomeStatmentService)
        {
            this.transactionRepo = transactionRepo;
            this.balanceService = balanceService;
            this.incomeStatmentService = incomeStatmentService;
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

            //TODO Add 10% revenue from goods
            if(transaction.CrTransactionEntry == PossibleTransactions.Goods)
            {
                await incomeStatmentService.updateincomestatmentWithRevenue(transaction.CrTransactionEntryValue);
            }

            transaction.Date = DateTime.Now;


            await transactionRepo.Create(transaction);
            //Update IncomeStatment


            //Update Balance Sheet
            await balanceService.UpdateLastBalance(transaction);

            // Add To database
        }
    }
}
