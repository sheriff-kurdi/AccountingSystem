using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Core.Enums
{
    public enum PossibleTransactions
    {
        //Assets
        Cash,
        AccountRecevable,
        Goods,
        Equipments,
        Building,
        Land,

        //Liabilities
        AccountPyable,
        SalaryPyable,
        //Loans,

        //Owner's Equity
        Capital
    }
}
