using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Logichroma.Models.Database;
using Logichroma.Models.DataRepositoryInterfaces;

namespace Logichroma.Models.DataRepositories
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly LogichromaDbEntities _db = new LogichromaDbEntities();
        
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