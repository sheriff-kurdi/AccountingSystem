using AccountingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystem.Core.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public double AccountReceivable { get; set; }
        public double AccountPyable { get; set; }
        [Required]
        public PossibleTransactions DrTransactionEntry { get; set; }
        [Required]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "You cannot create a transaction less than 1 pound ")]
        public double DrTransactionEntryValue { get; set; }
        [Required]
        public PossibleTransactions CrTransactionEntry { get; set; }
        [Required]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "You cannot create a transaction less than 1 pound ")]
        public double CrTransactionEntryValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }


        //public double Cash { get; set; }
        //public double Equipment { get; set; }
        //public double Land { get; set; }
        //public double Building { get; set; }
        //public double Goods { get; set; }




    }
}
