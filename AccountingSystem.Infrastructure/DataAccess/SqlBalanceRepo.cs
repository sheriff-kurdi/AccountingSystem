using AccountingSystem.Core.Entities;
using AccountingSystem.Core.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Infrastructure.DataAccess
{
    class SqlBalanceRepo : IBalanceRepo
    {
        private readonly ApplicationDbContext db;

        public SqlBalanceRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(Balance balance)
        {
            await db.Balances.AddAsync(balance);
        }

        public async Task<Balance> GetLastBalance()
        {
            return await db.Balances.LastOrDefaultAsync();
        }

        public async Task Update(Balance balance)
        {
            db.Balances.Update(balance);
            await db.SaveChangesAsync();


        }
    }
}
