using System;
using System.Collections.Generic;
using System.Text;
using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using AccountingSystem.Core.IRepo;

namespace AccountingSystem.Service.Transactions
{
    public class TransactionsEntriesService
    {
        private readonly ITransactionRepo transactionRepo;

        public TransactionsEntriesService(ITransactionRepo transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }

        public void CreateTransaction(Transaction transaction)
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

            //Console.WriteLine(nameof(transaction.Description));

            //string DrTransactionFromEnum = Enum.GetName(typeof(PossibleTransactions), 2);
            //Console.WriteLine(DrTransactionFromEnum);

            //Console.WriteLine(transaction.DrTransactionEntry);



            //TODO Date for calculating intrest
            //auto calculated VS manual calculate on cash flow

            transactionRepo.Create(transaction);

            // Add To database
        }
    }
}
