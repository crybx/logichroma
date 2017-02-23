using System.Collections.Generic;
using Pyrotechnics.Models.Database;

namespace Pyrotechnics.Models.DataRepositoryInterfaces
{
    public interface ICardRepository
    {
        IList<Card> GetCards();
        Card GetCardDetails(int id);
        void AddCard(Card card);
        void UpdateCard(Card card);
        void DeleteCard(int id);
    }
}
