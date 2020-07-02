using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Core.Entities
{
    public class IncomeStatment
    {

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        //Revenues
        public double SalesRevenue { get; set; }


        //Expenses
        public double Salary { get; set; }
        public double Rent { get; set; }
        public double Advertising { get; set; }
        public double Utilities { get; set; }


        //Totall if it with minus(NetLoss) plus(NetIncome)
        public double Totall { get; set; }




        //
    }
}
