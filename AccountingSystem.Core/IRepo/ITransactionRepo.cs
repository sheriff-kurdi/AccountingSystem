using AccountingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Core.IRepo
{
    public interface ITransactionRepo
    {
        public Task Create(Transaction transaction);
        public Task<IEnumerable<Transaction>> GetAll();


    }
}
