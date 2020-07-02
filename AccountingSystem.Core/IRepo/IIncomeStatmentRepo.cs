using AccountingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Core.IRepo
{
     public interface IIncomeStatmentRepo
    {
        public Task Create(IncomeStatment incomeStatment);
        public Task<IncomeStatment> GetLastIncomeStatment();
        public Task Update(IncomeStatment updatedIncomeStatment);
    }
}
