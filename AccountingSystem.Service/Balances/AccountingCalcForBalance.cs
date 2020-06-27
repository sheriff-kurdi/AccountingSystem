using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Service.Balances
{
    public class AccountingCalcForBalance
    {
        public void HandleCreditEntriesForBalance(Transaction transaction, Balance lastBalance)
        {

            //Credit
            //Assets
            if (transaction.DrTransactionEntry == PossibleTransactions.AccountRecevable)
            {
                lastBalance.AccountRecevable -= transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Building)
            {
                lastBalance.Building -= transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Cash)
            {
                lastBalance.Cash -= transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Equipments)
            {
                lastBalance.Equipments -= transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Goods)
            {
                lastBalance.Goods -= transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Land)
            {
                lastBalance.Land -= transaction.DrTransactionEntryValue;
            }


            //Liabilites
            if (transaction.DrTransactionEntry == PossibleTransactions.AccountPyable)
            {
                lastBalance.AccountPyable += transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Loans)
            {
                lastBalance.Loans += transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.SalaryPyable)
            {
                lastBalance.SalaryPyable += transaction.DrTransactionEntryValue;
            }


            //Owner's Equity
            if (transaction.DrTransactionEntry == PossibleTransactions.Capital)
            {
                lastBalance.Capital += transaction.DrTransactionEntryValue;
            }
        }
        public void HandleDebitEntriesForBalance(Transaction transaction, Balance lastBalance)
        {
            //Debit
            //Assets
            if (transaction.DrTransactionEntry == PossibleTransactions.AccountRecevable)
            {
                lastBalance.AccountRecevable += transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Building)
            {
                lastBalance.Building += transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Cash)
            {
                lastBalance.Cash += transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Equipments)
            {
                lastBalance.Equipments += transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Goods)
            {
                lastBalance.Goods += transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Land)
            {
                lastBalance.Land += transaction.DrTransactionEntryValue;
            }


            //Liabilites
            if (transaction.DrTransactionEntry == PossibleTransactions.AccountPyable)
            {
                lastBalance.AccountPyable -= transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.Loans)
            {
                lastBalance.Loans -= transaction.DrTransactionEntryValue;
            }
            if (transaction.DrTransactionEntry == PossibleTransactions.SalaryPyable)
            {
                lastBalance.SalaryPyable -= transaction.DrTransactionEntryValue;
            }


            //Owner's Equity
            if (transaction.DrTransactionEntry == PossibleTransactions.Capital)
            {
                lastBalance.Capital -= transaction.DrTransactionEntryValue;
            }

        }
        public void EditLastBalance(IEnumerable<Transaction> transactions, Balance lastBalance)
        {
            lastBalance.Date = DateTime.Now;
            foreach (Transaction transaction in transactions)
            {
                // Assets increase in debits nad decrease by credit
                // but liabilities & Owners equity is the oposite
                HandleDebitEntriesForBalance(transaction, lastBalance);
                HandleCreditEntriesForBalance(transaction, lastBalance);
            }
        }
    }
}
