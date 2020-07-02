using AccountingSystem.Core.Entities;
using AccountingSystem.Core.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Infrastructure.DataAccess
{
    public class SqlIncomeStatmentRepo : IIncomeStatmentRepo
    {
        private readonly ApplicationDbContext db;

        public SqlIncomeStatmentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(IncomeStatment incomeStatment)
        {
            await db.IncomeStatments.AddAsync(incomeStatment);
            await db.SaveChangesAsync();
        }

        public async Task<IncomeStatment> GetLastIncomeStatment()
        {
            return await db.IncomeStatments
                .OrderByDescending(i => i.Id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(IncomeStatment incomeStatment)
        {
            db.IncomeStatments.Update(incomeStatment);
            await db.SaveChangesAsync();


        }
    }
}
