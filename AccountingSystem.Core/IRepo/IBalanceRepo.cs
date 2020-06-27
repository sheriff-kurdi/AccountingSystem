using AccountingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Core.IRepo
{
    public interface IBalanceRepo
    {
        public Task Create(Balance balance);
        public Task<Balance> GetLastBalance();
        public Task Update(Balance updatedBalance);


    }
}
