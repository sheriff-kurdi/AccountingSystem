using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystem.Core.Entities
{
    public class Balance
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        //Assets
        public double Cash { get; set; }
        public double AccountRecevable { get; set; }
        public double Goods { get; set; }
        public double Equipments { get; set; }
        public double Land { get; set; }
        public double Building { get; set; }


        //Liablities
        public double AccountPyable { get; set; }
        public double SalaryPyable { get; set; }
        public double Loans { get; set; }


        //Owner's Equity
        public double Capital { get; set; }

        //total
        public double TotalAsset { get; set; }
     
        public double TotallLiabilityAndEquity { get; set; }







    }
}
