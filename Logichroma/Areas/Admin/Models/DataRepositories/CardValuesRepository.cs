using Logichroma.Areas.Admin.Models.DataRepositoryInterfaces;
using Logichroma.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Logichroma.Areas.Admin.Models.DataRepositories
{
    public class CardValuesRepository : ICardValuesRepository
    {
        private readonly LogichromaDbEntities _db = new LogichromaDbEntities();
        
        public IList<CardValue> GetCards()
        {
            return _db.CardValues.ToList();
        }

        public CardValue GetCardDetails(int id)
        {
            var card = _db.CardValues.Find(id);

            if (card == null)
            {
                throw new Exception("Card not found.");
            }

            return card;
        }

        public void AddCard(CardValue card)
        {
            _db.CardValues.Add(card);
            _db.SaveChanges();
        }

        public void UpdateCard(CardValue card)
        {
            _db.Entry(card).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCard(int id)
        {
            var card = _db.CardValues.Find(id);

            if (card == null) return;

            _db.CardValues.Remove(card);
            _db.SaveChanges();
        }
    }
}