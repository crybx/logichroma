using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pyrotechnics.Models.Database;
using Pyrotechnics.Models.DataRepositoryInterfaces;

namespace Pyrotechnics.Models.DataRepositories
{
    public class CardRepository : ICardRepository
    {
        private readonly PyrotechnicsDbEntities _db = new PyrotechnicsDbEntities();
        
        public IList<Card> GetCards()
        {
            return _db.Cards.ToList();
        }

        public Card GetCardDetails(int id)
        {
            var card = _db.Cards.Find(id);

            if (card == null)
            {
                throw new Exception("Card not found.");
            }

            return card;
        }

        public void AddCard(Card card)
        {
            _db.Cards.Add(card);
            _db.SaveChanges();
        }

        public void UpdateCard(Card card)
        {
            _db.Entry(card).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCard(int id)
        {
            var card = _db.Cards.Find(id);
            _db.Cards.Remove(card);
            _db.SaveChanges();
        }
    }
}