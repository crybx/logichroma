using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ChromaMatch.Models.Database;
using ChromaMatch.Models.DataRepositoryInterfaces;

namespace ChromaMatch.Models.DataRepositories
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly ChromaMatchDbEntities _db = new ChromaMatchDbEntities();
        
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