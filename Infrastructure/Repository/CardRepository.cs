using ApplicationCore.Domain.RepositoryContracts;
using BankData.Repository;
using Entities;
using Entities.BanksEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CardRepository :GenericRepository<CardEntity>, ICardRepository
    {
        private readonly DbSet<CardEntity> _dbSet;

        public CardRepository(BankAppContext context) :base(context) {
            _dbSet = context.Set<CardEntity>();
        }

        public Task<List<CardEntity>?> GetCardsListByBankId(int bankId)
        {
            return _dbSet.Where(card => card.BankId == bankId).ToListAsync();
        }
    }
}
