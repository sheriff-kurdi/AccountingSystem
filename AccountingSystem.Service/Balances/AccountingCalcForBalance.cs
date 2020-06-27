using AccountingSystem.Core.Entities;
using AccountingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Service.Balances
{
    public class AccountingCalcForBalance
    {
        public Balance HandleCreditEntriesForBalance( Transaction transaction, Balance lastBalance)
        {

            //Credit
            //Assets
            if (transaction.CrTransactionEntry == PossibleTransactions.AccountRecevable)
            {
                lastBalance.AccountRecevable -= transaction.DrTransactionEntryValue;
            }
            if (transaction.CrTransactionEntry == PossibleTransactions.Building)
            {
                lastBalance.Building -= transaction.DrTransactionEntryValue;
            }
            if (transaction.CrTransactionEntry == PossibleTransactions.Cash)
            {
                lastBalance.Cash -= transaction.DrTransactionEntryValue;
            }
            if (transaction.CrTransactionEntry == PossibleTransactions.Equipments)
            {
                lastBalance.Equipments -= transaction.DrTransactionEntryValue;
            }
            if (transaction.CrTransactionEntry == PossibleTransactions.Goods)
            {
                lastBalance.Goods -= transaction.DrTransactionEntryValue;
            }
            if (transaction.CrTransactionEntry == PossibleTransactions.Land)
            {
                lastBalance.Land -= transaction.DrTransactionEntryValue;
            }


            //Liabilites
            if (transaction.CrTransactionEntry == PossibleTransactions.AccountPyable)
            {
                lastBalance.AccountPyable += transaction.DrTransactionEntryValue;
            }
            if (transaction.CrTransactionEntry == PossibleTransactions.Loans)
            {
                lastBalance.Loans += transaction.DrTransactionEntryValue;
            }
            if (transaction.CrTransactionEntry == PossibleTransactions.SalaryPyable)
            {
                lastBalance.SalaryPyable += transaction.DrTransactionEntryValue;
            }


            //Owner's Equity
            if (transaction.CrTransactionEntry == PossibleTransactions.Capital)
            {
                lastBalance.Capital += transaction.DrTransactionEntryValue;
            }

            return lastBalance;
        }
        public Balance HandleDebitEntriesForBalance(Transaction transaction, Balance lastBalance)
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

            return lastBalance;

        }
        public Balance EditLastBalance(Transaction transaction, Balance lastBalance)
        {
            lastBalance.Date = DateTime.Now;

            // if you wanna edit balance in every transaction
            lastBalance =  HandleDebitEntriesForBalance(transaction, lastBalance);
            lastBalance= HandleCreditEntriesForBalance(transaction, lastBalance);

            //if you wanna create balance for whole old transactions

            //foreach (Transaction transaction in transactions)
            //{
            //    // Assets increase in debits nad decrease by credit
            //    // but liabilities & Owners equity is the oposite
            //    HandleDebitEntriesForBalance(transaction, lastBalance);
            //    HandleCreditEntriesForBalance(transaction, lastBalance);
            //}

            return lastBalance;
        }
    }
}
