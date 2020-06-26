using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.DomainEntities.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Cash { get; set; }
        public double AccountReceivable { get; set; }
        public double AccountPyable { get; set; }
        public double Equipment { get; set; }
        public double Land { get; set; }
        public double Building { get; set; }
        public double Goods { get; set; }
    

    }
}
