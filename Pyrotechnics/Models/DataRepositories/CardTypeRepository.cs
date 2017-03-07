using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pyrotechnics.Models.Database;
using Pyrotechnics.Models.DataRepositoryInterfaces;

namespace Pyrotechnics.Models.DataRepositories
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly PyrotechnicsDbEntities _db = new PyrotechnicsDbEntities();
        
        public IList<CardType> GetCards()
        {
            return _db.CardTypes.ToList();
        }

        public CardType GetCardDetails(int id)
        {
            var card = _db.CardTypes.Find(id);

            if (card == null)
            {
                throw new Exception("Card not found.");
            }

            return card;
        }

        public void AddCard(CardType card)
        {
            _db.CardTypes.Add(card);
            _db.SaveChanges();
        }

        public void UpdateCard(CardType card)
        {
            _db.Entry(card).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCard(int id)
        {
            var card = _db.CardTypes.Find(id);
            _db.CardTypes.Remove(card);
            _db.SaveChanges();
        }
    }
}