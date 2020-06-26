using AccountingSystem.DomainEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.DomainEntities.ViewModels
{
    class CreateTransactionVM
    {
        public string Description { get; set; }
        public PossibleTransactions DrTransaction { get; set; }
        public double DrValue { get; set; }
        public PossibleTransactions CrTransaction { get; set; }
        public double CrValue { get; set; }

    }
}
