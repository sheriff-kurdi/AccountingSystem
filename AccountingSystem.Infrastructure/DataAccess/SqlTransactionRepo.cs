using AccountingSystem.Core.Entities;
using AccountingSystem.Core.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Infrastructure.DataAccess
{
    public class SqlTransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext db;

        public SqlTransactionRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(Transaction transaction)
        {
            await db.Transactions.AddAsync(transaction);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await db.Transactions.ToListAsync();
        }
    }
}
